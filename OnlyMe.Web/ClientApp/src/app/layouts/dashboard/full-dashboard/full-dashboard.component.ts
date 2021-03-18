import { SidebarComponent } from './sidebar/sidebar.component';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-full-dashboard',
  templateUrl: './full-dashboard.component.html',
  styleUrls: ['./full-dashboard.component.scss']
})
export class FullDashboardComponent implements OnInit {
  @ViewChild('sidebar', { static: true }) sidebar: SidebarComponent;

  constructor() { }

  ngOnInit() {
  }

  onClickToggle(){
    this.sidebar.onClickToggle();
  }

}
