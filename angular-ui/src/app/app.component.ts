import { Component } from '@angular/core';
import { FormsModule, ReactiveFormsModule, FormGroup, FormBuilder, Validators } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule, ReactiveFormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'angular-ui';
  logo = 'logo.png';
  isLoading = false;
  calculatorForm: FormGroup;
  
  results = {
    avalphaTechnologiesCommission: 0,
    competitorCommission: 0
  };

  //Added form controls for individual field validation.
  constructor(private fb: FormBuilder) {
    this.calculatorForm = this.fb.group({
      localSalesCount: [0, [Validators.required, Validators.min(0)]],
      foreignSalesCount: [0, [Validators.required, Validators.min(0)]],
      averageSaleAmount: [0, [Validators.required, Validators.min(0)]]
    });
  }

  // Getter methods for easy access to form controls.
  get localSalesCount() { return this.calculatorForm.get('localSalesCount'); }
  get foreignSalesCount() { return this.calculatorForm.get('foreignSalesCount'); }
  get averageSaleAmount() { return this.calculatorForm.get('averageSaleAmount'); }

  handleSubmit() {
    if (this.calculatorForm.valid) {
      this.isLoading = true;
      
      const formValues = this.calculatorForm.value;
      const totalLocalSales = formValues.localSalesCount * formValues.averageSaleAmount;
      const totalForeignSales = formValues.foreignSalesCount * formValues.averageSaleAmount;
      
      const avalphaLocalCommission = totalLocalSales * 0.20;
      const avalphaForeignCommission = totalForeignSales * 0.35;
      this.results.avalphaTechnologiesCommission = avalphaLocalCommission + avalphaForeignCommission;
      
      const competitorLocalCommission = totalLocalSales * 0.02;
      const competitorForeignCommission = totalForeignSales * 0.0755;
      this.results.competitorCommission = competitorLocalCommission + competitorForeignCommission;
      
      setTimeout(() => {
        this.isLoading = false;
      }, 1000);
    } else {
      // Mark all fields as touched to show validation errors
      this.calculatorForm.markAllAsTouched();
    }
  }
}
