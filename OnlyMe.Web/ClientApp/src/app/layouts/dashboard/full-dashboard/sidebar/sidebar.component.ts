import { SidenavComponent } from './../../../../../../projects/ng-uikit-pro-standard/src/lib/pro/sidenav/sidenav.component';
import { Component, OnInit, ViewChild } from '@angular/core';

@Component({
  selector: 'app-sidebar',
  templateUrl: './sidebar.component.html',
  styleUrls: ['./sidebar.component.scss']
})
export class SidebarComponent implements OnInit {
  @ViewChild('sidenav', { static: true }) sidenav: SidenavComponent;
  constructor() { }

  ngOnInit() {
    
  }

  onClickToggle(){
    this.sidenav.toggle();
  }

}
