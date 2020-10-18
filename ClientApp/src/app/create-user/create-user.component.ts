import { Component, OnInit } from '@angular/core';
import { FormGroup, FormControl, Validators, FormBuilder } from '@angular/forms';
import { UserCredentials } from '../shared/user-credentials.model';
import { DataService } from '../shared/data.service';

@Component({
  selector: 'create-user',
  templateUrl: './create-user.component.html',
  styleUrls: ['./create-user.component.css']
})
export class CreateUserComponent implements OnInit {
  constructor(private formBuilder: FormBuilder,
    private dataService: DataService) { }

  createUserForm: FormGroup;
  username: FormControl;

  ngOnInit() {
    this.createFormControls();
    this.createForm();
  }

  createFormControls() {
    this.username = new FormControl('', Validators.required);
  }
  createForm() {
    this.createUserForm = this.formBuilder.group({
      username: this.username
    })
  }

  onUserCreate() {
    const creds: UserCredentials = { username: this.username.value };
    this.dataService.createUser(creds).subscribe((isSuccess) => {
      if (isSuccess) {
        let temp = isSuccess;
      }
    })
  }
}
