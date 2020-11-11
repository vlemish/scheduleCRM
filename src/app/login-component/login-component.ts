import { Component, HostListener, OnDestroy, OnInit } from '@angular/core';
import { faEye, faEyeSlash } from '@fortawesome/free-regular-svg-icons';
import { LoginService } from '../services/login.service';
import { User } from '../models/user';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login-component',
  templateUrl: './login-component.html',
  styleUrls: ['./login-component.css']
  
})
export class LoginComponent implements OnInit, OnDestroy {

  constructor(private router: Router ,private loginService : LoginService) { }

  //instance of a user to form the user from input's fields data
  user : User = new User(null, null);
  //varible to store an icon
  faEye = faEye;
  //boolen variable to change input's type
  isPasswordShowable : boolean = false;
  //variable to store a type of password it can be either password(not viewable) or text(viewable)
  passwordType : string = "password";

  //to show the message that givven password or username isn't correct
  private errorMessage : string = "";
  get ErrorMessage(){
    if(!this.isCorrectData){
      this.errorMessage =  "*Username or password is incorrect";
    }
    else{
      this.errorMessage = "";
    }
    return this.errorMessage;
  }

  //a variable with a class to dynamically change validation of username input field
  private usernameClass : string = "wrap-input100 validate-input";
  get UsernameClass(){
    return this.usernameClass;
  }
  
  //a variable with a class to dynamically change validation of password input field
  private passwordClass : string = "wrap-input100 validate-input";
  get PasswordClass(){
    return this.passwordClass;
  }
  
  //a varible to check whether the user with this username and this pasword exist
  isCorrectData : boolean = true;

  //array with anchors
  ngOnInit(): void {
    let appWrapper = document.getElementById("container");
    appWrapper.classList.remove("container");
    appWrapper.classList.remove("body-content");    
    let bodyStyle = document.getElementById("_body");
    bodyStyle.style.backgroundColor="#ebebeb";
  }

  ngOnDestroy() : void{
    let bodyStyle = document.getElementById("_body");
    bodyStyle.style.backgroundColor="white";
    let appWrapper = document.getElementById("container");
    appWrapper.classList.add("container");
    appWrapper.classList.add("body-content");
  }

  //changes input type from password to text or in opposite direction (from text to password)
  showPassword(){
    if(!this.isPasswordShowable){     
      this.faEye = faEyeSlash;
      this.passwordType = "text";
      this.isPasswordShowable = true;
    }
    else{
      this.faEye = faEye;
      this.passwordType = "password";
      this.isPasswordShowable=false;
    }
  }

  //adds or removes 'alert-validate' class from default usernameClass
  onUsernameBlur(){
    if(this.user.username===null || this.user.username===""){
      this.usernameClass = "wrap-input100 validate-input alert-validate";
    }
    else{
      this.usernameClass = "wrap-input100 validate-input";
    }
  }

  //adds or removes 'alert-validate' class from default passwordClass
  onPasswordBlur(){
    if(this.user.password===null || this.user.password===""){
      this.passwordClass = "wrap-input100 validate-input alert-validate";
    }
    else{
      this.passwordClass = "wrap-input100 validate-input";
    }
  }

  //sends formed user to the server and gets the response. If the user is exist it means that the data has spelled correct, so client will be redirected to another page and etc.
  //If the user doesn't exist, isCorrectData variable would change to false and that would return to client an error message  
  loginUser(){
    if(this.user.username===null || this.user.password===null){
      this.onUsernameBlur();
      this.onPasswordBlur();
      return;
    }
    this.loginService.logIn(this.user).subscribe((response : any)=>{
        this.isCorrectData = true;
        this.loginService.setToken(response.token);
        this.loginService.setIdentity(response.identity);
        console.log(this.loginService.getToken());
        console.log(this.loginService.getIdentity());
        this.router.navigate(['/main']);
    },
    err=>{
      if(err.status == 400){
        this.isCorrectData=false;
        this.loginService.removeToken('token');
        this.loginService.removeIdentity('identity');
      }
    });
  }
  //sets the identity to the Guest, the user will have all the resources that allowed for the Guest identity 
  loginGuest(){
    this.loginService.setIdentity('Guest');
    this.loginService.setToken('tooooooooooooooooooooooooooooooooooooollllllllllllllllllkkkkkkkkken');
    this.router.navigate(['main']);
  }
  scrollTo(id : string){
    window.location.hash = id;
  }
}