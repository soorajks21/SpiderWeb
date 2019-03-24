import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../_services/auth.service';
import { AlertifyService } from '../_services/alertify.service';


@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

@Output() cancelRegister = new  EventEmitter();
  model: any = {};
  constructor(private authService: AuthService, private alerify: AlertifyService) { }

  ngOnInit() {
  }

  register(){
    this.authService.register(this.model).subscribe(() =>{
  this.alerify.sucess('registeration successfull');
    },
    error => {
     this.alerify.error(error);
    } );
  
  }

  cancel(){
    this.cancelRegister.emit(false);
   
  }
}
