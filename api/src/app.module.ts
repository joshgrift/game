import { Module } from '@nestjs/common';
import { AppController } from './app.controller';
import { AppService } from './app.service';
import { GamesController } from './controllers/games.controller';
import { DatabaseService } from './services/database.service';

@Module({
  imports: [],
  controllers: [AppController, GamesController],
  providers: [AppService, DatabaseService],
})
export class AppModule {}
