import { Game } from '../../../common/types';

export class API {
  BASE_URL = "http://localhost:3001";

  private async api(method:string, url:string, body:any = null): Promise<any> {
    let response = await fetch(this.BASE_URL + url, {
      headers: {
        'Accept': 'application/json',
        'Content-Type': 'application/json'
      },
      method,
      body
    });

    // TODO: error detection

    return await response.json();
  }

  async getGames():Promise<Game[]> {
    return await this.api("GET", '/games') as Game[];
  }
}