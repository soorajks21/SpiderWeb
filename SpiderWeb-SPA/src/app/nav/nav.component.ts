import { Component, OnInit } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { error } from '@angular/compiler/src/util';
import { AlertifyService } from '../_services/alertify.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-nav',
  templateUrl: './nav.component.html',
  styleUrls: ['./nav.component.css']
})
export class NavComponent implements OnInit {

 
  constructor(public authService: AuthService, private alerify: AlertifyService, private router: Router) { }
  model: any = {};
  


  ngOnInit() {
  }

  login(){
  this.authService.login(this.model).subscribe(next =>{
    this.alerify.sucess('Logged in Successfully');
   
  },
   error => {
    this.alerify.error(error);
  }, () =>{
    this.router.navigate(['/members']);
  });
}

  loggedIn(){
   return this.authService.loggedIn();
  }

  logOut(){
    localStorage.removeItem('token');
    this.alerify.message('logged out');
    this.router.navigate(['/home']);
  }
}
