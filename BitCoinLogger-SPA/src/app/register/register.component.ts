import { Component, OnInit, Input, Output, EventEmitter } from '@angular/core';
import { AuthService } from '../services/auth.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {
  @Output() cancelRegister = new EventEmitter();
  model: any = {};
  showRegister = true;
  constructor(private authService: AuthService, private router: Router) { }

  ngOnInit() {
  }

  register() {
    this.authService.register(this.model).subscribe(() => {
      this.showRegister = false;
      this.router.navigate(['/home']);
      console.log('Registered succesfully');
    }, error => {
      console.log('Failed to register');
    });

  }

  cancel() {
    this.cancelRegister.emit(false);
    console.log('Cancelled!');
  }

}
