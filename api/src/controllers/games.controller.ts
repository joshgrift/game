import {
  BadRequestException,
  Body,
  Controller,
  Delete,
  Get,
  Param,
  Post,
  Put,
} from '@nestjs/common';
import { DatabaseService } from 'src/services/database.service';
import { Game } from '../../../common/types';

@Controller('games')
export class GamesController {
  constructor(private readonly databaseService: DatabaseService) {}

  @Get()
  getActiveGames(): { games: Game[] } {
    return {
      games: this.databaseService.getGames(),
    };
  }

  @Post()
  createGame(): Game {
    return this.databaseService.createGame();
  }

  @Delete('/:game')
  deleteGame(@Param('game') gameId: string): void {
    this.databaseService.deleteGame(gameId);
  }

  @Put('/:game/player')
  joinGame(@Param('game') gameId: string, @Body('id') playerId: string): Game {
    if (!playerId) {
      throw new BadRequestException('Missing player id');
    }
    return this.databaseService.addPlayer(gameId, { id: playerId });
  }

  @Delete('/:game/player')
  leaveGame(@Param('game') gameId: string, @Body('id') playerId: string): Game {
    if (!playerId) {
      throw new BadRequestException('Missing player id');
    }
    return this.databaseService.deletePlayer(gameId, playerId);
  }
}
