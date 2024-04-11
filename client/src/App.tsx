import { useEffect, useState } from 'react';
import './App.css';
import { API } from './lib/api';
import { Game } from '../../common/types';

let api = new API();

function App() {
  const [games, setGames] = useState<Game[]>([]);

  useEffect(() => {
    (async () => {
      setGames(await api.getGames());
    })();
  }, []);

  return (
    <div className="App">
      <header className="App-header">
        Cool stuff
      </header>
      <div className="list">
        <ul>
          {games.map((game, index) => (
            <li key={index}>{game.id} | {game.players.length} players | <button type="button">Join</button> | <button type="button">Delete</button></li>
          ))}
        </ul>
      </div>
      <button type="button">Create Game</button>
    </div>
  );
}

export default App;
