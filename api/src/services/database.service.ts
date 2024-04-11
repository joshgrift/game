import {
  ConflictException,
  Injectable,
  NotFoundException,
} from '@nestjs/common';
import { Game, Player } from '../../../common/types';

@Injectable()
export class DatabaseService {
  private gamesDb: { [key: string]: Game } = {
    game1: {
      id: 'game1',
      players: [
        {
          id: 'player1',
        },
      ],
    },
  };

  getGames(): Game[] {
    return Object.values(this.gamesDb);
  }

  createGame(): Game {
    const game = {
      id: (Math.random() * 0xfffff * 1000000).toString(16),
      players: [],
    };

    this.gamesDb[game.id] = game;

    return game;
  }

  deleteGame(gameId: string): void {
    if (!(gameId in this.gamesDb)) throw new NotFoundException();

    delete this.gamesDb[gameId];
  }

  addPlayer(gameId: string, player: Player): Game {
    if (!(gameId in this.gamesDb)) throw new NotFoundException();

    for (const p of this.gamesDb[gameId].players) {
      if (p.id == player.id) {
        throw new ConflictException(
          'A player is already in this lobby with that id',
        );
      }
    }

    this.gamesDb[gameId].players.push(player);

    return this.gamesDb[gameId];
  }

  deletePlayer(gameId: string, playerId: string): Game {
    if (!(gameId in this.gamesDb)) throw new NotFoundException();
    const players = this.gamesDb[gameId].players;

    for (const player in players) {
      if (players[player].id == playerId) {
        players.splice(Number(player), 1);

        return this.gamesDb[gameId];
      }
    }

    throw new NotFoundException('This player was not found on this game');
  }
}
