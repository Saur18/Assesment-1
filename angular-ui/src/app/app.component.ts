import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [FormsModule, CommonModule],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'angular-ui';
  logo = 'logo.png'; // Files in public/ are served from root
  isLoading = false;
  
  formData = {
    localSalesCount: 0,
    foreignSalesCount: 0,
    averageSaleAmount: 0
  };
  
  results = {
    avalphaTechnologiesCommission: 0,
    competitorCommission: 0
  };

  handleSubmit() {
    this.isLoading = true;
    
    const totalLocalSales = this.formData.localSalesCount * this.formData.averageSaleAmount;
    const totalForeignSales = this.formData.foreignSalesCount * this.formData.averageSaleAmount;
    
    const avalphaLocalCommission = totalLocalSales * 0.20;
    const avalphaForeignCommission = totalForeignSales * 0.35;
    this.results.avalphaTechnologiesCommission = avalphaLocalCommission + avalphaForeignCommission;
    
    const competitorLocalCommission = totalLocalSales * 0.02;
    const competitorForeignCommission = totalForeignSales * 0.0755;
    this.results.competitorCommission = competitorLocalCommission + competitorForeignCommission;
    
    setTimeout(() => {
      this.isLoading = false;
    }, 1000);
  }
}
