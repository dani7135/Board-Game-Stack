import { HttpClient } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';



interface BoardGame {
  title: string;
  playingTime: number;
  yearpublished: number;
  summary: string;
}

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit {
  public forecasts: BoardGame[] = [];

  constructor(private http: HttpClient) {}

  ngOnInit() {
    this.getForecasts();
  }

  getForecasts() {
    this.http.get<BoardGame[]>('/boardgame').subscribe(
      (result) => {
        this.forecasts = result;
      },
      (error) => {
        console.error(error);
      }
    );
  }

  title = 'board-game-stack.client';
}
