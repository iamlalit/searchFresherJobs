var searchApiUrl = 'http://localhost:51610/api/SearchAPI/';
var apiEndpointUrl = 'http://localhost:51610/api/';
//var searchApiUrl = 'http://52.10.247.75:8082/api/SearchAPI/';


//for local
var URLvariable = '/SearchFresherJobs/';

var genderCollection = [
       { id: '0', name: '<Select>' },
       { id: '1', name: 'Male' },
       { id: '2', name: 'Female' },
];

var maritalStatusCollection = [
       { id: '0', name: '<Select>' },
       { id: '1', name: 'Single/Unmarried' },
       { id: '2', name: 'Married' },
];

var statesCollection = [
       { id: '0', name: '<Select>' },
       { id: '1', name: 'Andaman and Nicobar Islands' },
       { id: '2', name: 'Arunachal Pradesh' },
       { id: '3', name: 'Andhra Pradesh' },
       { id: '4', name: 'Assam' },
       { id: '5', name: 'Bihar' },
       { id: '6', name: 'Chandigarh' },
       { id: '7', name: 'Chhattisgarh' },
       { id: '8', name: 'Dadra and Nagar Haveli' },
       { id: '9', name: 'Daman and Diu' },
       { id: '10', name: 'Delhi' },
       { id: '11', name: 'Goa' },
       { id: '12', name: 'Gujarat' },
       { id: '13', name: 'Haryana' },
       { id: '14', name: 'Himachal Pradesh' },
       { id: '15', name: 'Jammu and Kashmir' },
       { id: '16', name: 'Jharkhand' },
       { id: '17', name: 'Karnataka' },
       { id: '18', name: 'Kerala' },
       { id: '19', name: 'Lakshadweep' },
       { id: '20', name: 'Madhya Pradesh' },
       { id: '21', name: 'Maharashtra' },
       { id: '22', name: 'Manipur' },
       { id: '23', name: 'Meghalaya' },
       { id: '24', name: 'Mizoram' },
       { id: '25', name: 'Nagaland' },
       { id: '26', name: 'Orissa' },
       { id: '27', name: 'Pondicherry' },
       { id: '28', name: 'Punjab' },
       { id: '29', name: 'Rajasthan' },
       { id: '30', name: 'Sikkim' },
       { id: '2', name: 'Tamil Nadu' },
       { id: '2', name: 'Tripura' },
       { id: '2', name: 'Uttar Pradesh' },
       { id: '2', name: 'Uttaranchal' },
       { id: '2', name: 'West Bengal' },
];

var preferredLocationCollection = [
   { id: '100', name: 'Delhi-NCR' },
   { id: '200', name: 'Hyderabad' },
   { id: '300', name: 'Chennai' },
   { id: '400', name: 'Pune' },
   { id: '500', name: 'Bangluru' },
   { id: '600', name: 'Kolkata' },
];
//sort order is the order in which they appear and name followed by pipe and id 
var industryCollection = [
   { id: '100', name: 'Animation' },
   { id: '500', name: 'BPO-ITES' },
   { id: '1000', name: 'IT Software Services' },
   { id: '1500', name: 'IT Networking' },
   { id: '2000', name: 'Human Resources' },
];

var functionalAreaCollection = [
   { id: '50', name: 'IT Software - ERP / CRM' },
   { id: '100', name: 'IT Software Mainframe' },
   { id: '150', name: 'IT Software - Network Administration / Security' },
   { id: '200', name: 'IT Software - QA &amp; Testing' },
   { id: '250', name: 'IT Software - Systems / EDP / MIS' },
   { id: '300', name: 'IT- Hardware / Telecom / Technical Staff / Support' },
   { id: '350', name: 'ITES / BPO / KPO / Customer Service / Operations' },
];

//for server
//var URLvariable = '/';