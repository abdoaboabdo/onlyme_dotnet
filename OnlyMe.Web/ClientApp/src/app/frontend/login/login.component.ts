import { Component, OnInit } from '@angular/core';
import {  FormControl, FormGroup, Validators } from '@angular/forms';
import { JarwisService } from 'src/app/_services/authentication/jarwis.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements OnInit {
  profileForm:FormGroup;
  constructor(private jarwisService:JarwisService) { }

  ngOnInit() {
    this.profileForm=new FormGroup({
      userName:new FormControl('',Validators.required),
      password:new FormControl('',Validators.required)
    });
  }
  onSubmit(){
    this.jarwisService.login(this.profileForm.value).subscribe(data=>console.log(data));
    
  }

}
