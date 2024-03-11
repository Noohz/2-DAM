import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  email = new FormControl('', [Validators.required, Validators.email]);
  password = new FormControl('', [Validators.required, Validators.required]);
  hide = true;

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'Este campo es obligatorio';
    }

    return this.email.hasError('email') ? 'El email no es válido' : '';
  }

  constructor(private http: HttpClient) { }
  logearse() {
    if (this.email.valid && this.password.valid) {
      const user = {
        email: this.email.value,
        pwd: this.password.value
      };

      this.http.get(`http://moralo.atwebpages.com/menuAjax/chat/SeleccionarUsuario.php?email=${user.email}&pwd=${user.pwd}`)
        .subscribe((response: any) => {
          if (response.registrado) {
            alert('Usuario registrado');
          } else {
            alert('Usuario no registrado');
          }
        }, (error) => {
          console.error('No entra en el login', error);
        });
    }
  }
}
