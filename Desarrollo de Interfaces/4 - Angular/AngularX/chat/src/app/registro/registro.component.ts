import { HttpClient } from '@angular/common/http';
import { Component } from '@angular/core';
import { FormControl, Validators } from '@angular/forms';

@Component({
  selector: 'app-registro',
  templateUrl: './registro.component.html',
  styleUrl: './registro.component.css'
})
export class RegistroComponent {
  user = new FormControl('', [Validators.required, Validators.required]);
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

  registrarUsuario() {
    if (this.user.valid && this.email.valid && this.password.valid) {
      const userData = {
        user: this.user.value,
        email: this.email.value,
        password: this.password.value
      };
      this.http.post('http://moralo.atwebpages.com/menuAjax/chat/AltaUsuario.php', userData)
        .subscribe(response => {
          console.log('Entra en la creación de usuario', response);
          this.user.reset();
          this.email.reset();
          this.password.reset();
        }, error => {

          console.error('No entra en la creación de usuario', error);
        });
    }
  }
}
