import { useEffect, useState } from 'react';
import './App.css';
import { API } from './lib/api';
import { Game } from '../../common/types';

export default function Menu() {
  let api = new API();

  const [games, setGames] = useState<Game[]>([]);
  const [playerName, setPlayerName] = useState<string>("test1");

  async function refresh() {
    setGames(await api.getGames());
  }

  useEffect(() => {
    refresh();
  });

  let join = async (game:string) => {
    await api.joinGame(game, playerName);
    refresh();
  }

  let deleteGame = async (game:string) => {
    await api.deleteGame(game);
    refresh();
  }

  let createGame = async () => {
    await api.createGame();
    refresh();
  }

  function handlePlayerNameChange(e:React.ChangeEvent<HTMLInputElement>){
    setPlayerName(e.target.value);
  }

  return (
    <div className="Menu">
      <header className="App-header">
        Cool stuff
      </header>
      <input type="text" value={playerName} onChange={handlePlayerNameChange}></input>
      <div className="list">
        <ul>
          {games.map((game, index) => (
            <li key={index}>
              {game.id} | {game.players.length} players |
               <button onClick={() => join(game.id)} type="button">Join</button> 
               | <button type="button" onClick={() => deleteGame(game.id)}>Delete</button></li>
          ))}
        </ul>
      </div>
      <button type="button" onClick={() => createGame()}>Create Game</button>
    </div>
  );
}