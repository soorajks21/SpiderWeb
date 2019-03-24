import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { error } from '@angular/compiler/src/util';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

 
  constructor(private authService: AuthService) { }
  model: any = {}

  ngOnInit() {
  }

  login(){
  this.authService.login(this.model).subscribe(next =>{
    console.log(' Logged ');
  },
   error => {
    console.log(error);
  } 
  )}

  loggedIn(){
    const token = localStorage.getItem('token');
    return !!token;
  }

  logOut(){
    localStorage.removeItem('token');
    console.log('logged out');
  }
}
