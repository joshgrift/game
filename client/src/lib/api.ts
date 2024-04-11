import { Game } from '../../../common/types';

async function parseJson(response: Response):Promise<any> {
  const text = await response.text()
  try{
    if(text === ""){
      return {};
    }
    const json = JSON.parse(text)
    return json
  } catch(err) {
    throw new Error("Did not receive JSON, instead received: " + text)
  }
}

export class API {
  BASE_URL = "http://localhost:3001";

  private async api(method:string, url:string, payload:any = null): Promise<any> {
    let body = null;
    if(payload){
      body = JSON.stringify(payload);
    }
    let response = await fetch(this.BASE_URL + url, {
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      method,
      body
    });

    // TODO: error detection

    return parseJson(response);
  }

  async getGames():Promise<Game[]> {
    let games = await this.api("GET", '/games');

    return games.games as Game[];
  }

  async joinGame(game:string, playerId: string):Promise<Game> {
    let joinRes = await this.api("PUT", `/games/${game}/player`, {
      id: playerId
    })

    return joinRes.game as Game;
  }

  async deleteGame(game:string):Promise<void> {
    await this.api("DELETE", `/games/${game}`);
  }

  async createGame():Promise<Game> {
    return await this.api("POST", `/games`);
  }
}