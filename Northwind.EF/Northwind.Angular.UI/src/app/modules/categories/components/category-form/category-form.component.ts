import { Component, OnInit, TemplateRef } from '@angular/core';
import { FormBuilder, FormGroup, Validators  } from '@angular/forms';
import { HttpClient } from '@angular/common/http';
import { DbConnectionService } from '../../services/db-cat-connection.service';

import { CategoryModel } from '../..//models/CategoryModel';
import { BsModalService } from 'ngx-bootstrap/modal';
import { BsModalRef } from 'ngx-bootstrap/modal/bs-modal-ref.service';
import { ToastrService } from 'ngx-toastr';
import Swal from 'sweetalert2';

@Component({
  selector: 'app-category-form',
  templateUrl: './category-form.component.html',
  styleUrls: ['./category-form.component.css']
})

export class CategoryFormComponent implements OnInit {

  err = null;
  isLoading = false;
  modalRef: BsModalRef;
  formValue: FormGroup;
  categoryModel : CategoryModel = new CategoryModel;

  showAdd!: boolean;
  showUpdate!: boolean;

  minLengthCategoryName: number = 4;
  maxLengthCategoryName: number = 15;

  maxLengthDescription: number = 255;

  public categories: Array<CategoryModel> = [];

  constructor(private httpclient:     HttpClient,
              private apiService:     DbConnectionService,
              private modalService:   BsModalService,
              private fb:             FormBuilder,
              private toastrService:  ToastrService) { }

  openModal(template: TemplateRef<any>) {
    this.modalRef = this.modalService.show(template,{ backdrop: 'static', keyboard: false });
  }

  notValidField(field: string){

    return this.formValue.controls[field].errors
        && this.formValue.controls[field].touched;
  }

  ngOnInit() {

    this.getCategories();

    this.formValue = this.fb.group({
      CategoryName : ['', [Validators.required, Validators.minLength(this.minLengthCategoryName),
         Validators.maxLength(this.maxLengthCategoryName)]],
      Description : ['', [Validators.required, Validators.maxLength(this.maxLengthDescription)]]
    })
  }

  getCategories(){

    this.isLoading = true;
    this.apiService.getAllCategories()
    .subscribe(res => {

      this.isLoading = false;
      this.categories = res;

    },
    err => {

      this.isLoading = false;
      this.err = err.message
      this.toastrService.error('Error getting list - ' + err.message)
    });
  }

  insertCategoryDetails(){

    if(this.formValue.invalid){
      this.formValue.markAllAsTouched();
      return;
    }

    this.categoryModel.CategoryName = this.formValue.value.CategoryName;
    this.categoryModel.Description = this.formValue.value.Description;

    this.apiService.addCategory(this.categoryModel)
    .subscribe(res =>{

      this.formValue.reset();
      this.toastrService.success('New Category added!')
      this.getCategories();

    },
    err => {
      this.err = err.message
      this.toastrService.error('Error to create a new Category - ' + err.message)
    });
  }

  onEdit(category: CategoryModel){

    this.showAdd = false;
    this.showUpdate = true;

    this.categoryModel.CategoryID = category.CategoryID;
    this.formValue.controls['CategoryName'].setValue(category.CategoryName)
    this.formValue.controls['Description'].setValue(category.Description)
  }

  updateCategoryDetails(){

    if(this.formValue.invalid){
      this.formValue.markAllAsTouched();
      return;
    }

    this.categoryModel.CategoryName = this.formValue.value.CategoryName;
    this.categoryModel.Description = this.formValue.value.Description;

    this.apiService.updateCategory(this.categoryModel, this.categoryModel.CategoryID)
    .subscribe( res =>{
      this.toastrService.success('Successful Category update.')
      this.getCategories();

    },
    err =>{
      this.err = err.message
      this.toastrService.error('Update error - ' + err.message)
    });
  }

  deleteCategory(category: CategoryModel) {
    Swal.fire({
      title: 'Confirm',
      html: `Are you sure you want to delete?: <b>${ category.CategoryName }</b>?`,
      icon: 'warning',
      showCancelButton: true,
      confirmButtonText: 'CONFIRM',
      cancelButtonText: 'CANCEL'
    }).then((result:any) => {
      if (result.value) {
        Swal.fire({
            title: 'Please wait...',
            showConfirmButton: false,
        });
        Swal.showLoading();
        this.apiService.deleteCategory(category.CategoryID).subscribe({
          next: res => {
            this.getCategories();
            Swal.close();
            setTimeout(function() {
            }, 4000);
          },
          error: err => {
            Swal.close();
            Swal.fire({
              icon: 'error',
              title: 'Oops...',
              text: 'Error'
            });
          }
        });
      }
    });
  }

  clickBtnAdd(){
    this.formValue.reset();
    this.showAdd = true;
    this.showUpdate = false;
  }
}
