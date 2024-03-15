import { Test, TestingModule } from '@nestjs/testing';
import { GamesController } from './games.controller';
import { DatabaseService } from 'src/services/database.service';

describe('GameController', () => {
  let gamesController: GamesController;

  beforeEach(async () => {
    const app: TestingModule = await Test.createTestingModule({
      controllers: [GamesController],
      providers: [DatabaseService],
    }).compile();

    gamesController = app.get<GamesController>(GamesController);
  });

  describe('root', () => {
    it('should return "Hello World!"', () => {
      expect(gamesController.getActiveGames()).toBe(['test']);
    });
  });
});
