import { Component } from '@angular/core';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent {
  title = 'RocketFinUI';
  sidebarOpen = true;

  toggleSidebar(){
    this.sidebarOpen = this.sidebarOpen ? false : true;
  }
}
