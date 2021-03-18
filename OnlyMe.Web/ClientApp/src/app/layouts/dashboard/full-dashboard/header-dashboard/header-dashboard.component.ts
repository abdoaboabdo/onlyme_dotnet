import { Component, OnInit, Output, EventEmitter } from '@angular/core';
import { Category } from 'src/app/_models/category/category';

@Component({
  selector: 'app-header-dashboard',
  templateUrl: './header-dashboard.component.html',
  styleUrls: ['./header-dashboard.component.scss']
})
export class HeaderDashboardComponent implements OnInit {
  
  category:Category


  @Output() sidenav = new EventEmitter<string>();

  constructor() {
   }

  ngOnInit() {
    
  }


  onClickToggle() {
    this.sidenav.emit('clicked');
  }

}
