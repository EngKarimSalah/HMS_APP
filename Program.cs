namespace HMS_APP
{
    internal class Program
    {
        static void Main(string[] args) //startig point
        {
            // System Storage

            string[] patientNames = new string[100];
            string[] patientIDs = new string[100];
            string[] diagnoses = new string[100];
            bool[] admitted = new bool[100];
            string[] assignedDoctors = new string[100];
            string[] departments = new string[100];
            int[] visitCount = new int[100];
            double[] billingAmount = new double[100];

            // Patient[] patients = new Patient[100];

            //////////////////////////////////////////////////////


            // Seed Data
            /////////////////////////////////////////////////////
            int lastIndex = 0;

     
            patientNames[lastIndex] = "Ali Hassan";
            patientIDs[lastIndex] = "P001";
            diagnoses[lastIndex] = "Flu";
            departments[lastIndex] = "General";
            admitted[lastIndex] = false;
            assignedDoctors[lastIndex] = ""; 
            visitCount[lastIndex] = 2;
            billingAmount[lastIndex] = 0;

            lastIndex++;

            patientNames[lastIndex] = "Sara Ahmed";
            patientIDs[lastIndex] = "P002";
            diagnoses[lastIndex] = "Fracture";
            departments[lastIndex] = "Orthopedics";
            admitted[lastIndex] = true;
            assignedDoctors[lastIndex] = "Dr. Noor";
            visitCount[lastIndex] = 4;
            billingAmount[lastIndex] = 0;

            lastIndex++;

            patientNames[lastIndex] = "Omar Khalid";
            patientIDs[lastIndex] = "P003";
            diagnoses[lastIndex] = "Diabetes";
            departments[lastIndex] = "Cardiology";
            admitted[lastIndex] = false;
            assignedDoctors[lastIndex] = "";
            visitCount[lastIndex] = 1;
            billingAmount[lastIndex] = 0;
            ////////////////////////////////////////////////////////////////////




            bool exit = false;

            while (exit == false)
            {
                Console.WriteLine("===== Healthcare Management System =====");
                Console.WriteLine("----------------------------------------");
                Console.WriteLine("1.  Register New Patient");  //1 easy
                Console.WriteLine("2.  Admit Patient");//4 easy
                Console.WriteLine("3.  Discharge Patient");
                Console.WriteLine("4.  Search Patient"); //2 easy
                Console.WriteLine("5.  List All Admitted Patients"); //3 easy
                Console.WriteLine("6.  Transfer Patient to Another Doctor");
                Console.WriteLine("7.  View Most Visited Patients");
                Console.WriteLine("8.  Search Patients by Department");
                Console.WriteLine("9.  Billing Report");
                Console.WriteLine("10. Exit");
                Console.Write("Choose option: ");

                int choice = int.Parse(Console.ReadLine());

                switch (choice)
                {




                    case 1: // Register New Patient
                        lastIndex++;

                        Console.Write("Patient Name: ");
                        patientNames[lastIndex] = Console.ReadLine();

                        //Console.Write("Patient ID: ");
                        //patientIDs[lastIndex] = Console.ReadLine();

                        Console.Write("Diagnosis: ");
                        diagnoses[lastIndex] = Console.ReadLine();

                        Console.Write("Department: ");
                        departments[lastIndex] = Console.ReadLine();


                        patientIDs[lastIndex] = "P00" + lastIndex;
                        admitted[lastIndex] = false;
                        assignedDoctors[lastIndex] = "";
                        visitCount[lastIndex] = 0;
                        billingAmount[lastIndex] = 0;

                        Console.WriteLine("Patient registered successfully with ID :" + patientIDs[lastIndex]);
                        break;

                    case 2: // Admit Patient
                        Console.Write("Enter Patient ID or Name: ");
                        string admitInput = Console.ReadLine();

                        bool admitFound = false;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (patientNames[i] == admitInput || patientIDs[i] == admitInput)
                            {
                                admitFound = true;

                                if (admitted[i] == false)
                                {
                                    Console.Write("Doctor Name: ");
                                    assignedDoctors[i] = Console.ReadLine();

                                    admitted[i] = true;
                                    visitCount[i]++;

                                    Console.WriteLine("Patient admitted successfully and assigned to " + assignedDoctors[i]);
                                    Console.WriteLine("This patient has been admitted " + visitCount[i] + " times");
                                }
                                else
                                {
                                    Console.WriteLine("Patient is already admitted under " + assignedDoctors[i]);
                                }

                                break;
                            }
                        }

                        if (admitFound == false)
                        {
                            Console.WriteLine("Patient not found");
                        }

                        break;

                    case 3: // Discharge Patient
                        Console.Write("Enter Patient ID or Name: ");
                        string dischargeInput = Console.ReadLine();

                        bool dischargeFound = false;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (patientNames[i] == dischargeInput || patientIDs[i] == dischargeInput)
                            {
                                dischargeFound = true;

                                if (admitted[i] == true)
                                {
                                    double visitCharges = 0;

                                    Console.Write("Was there a consultation fee? (yes/no): ");
                                    string hasFee = Console.ReadLine().ToLower();

                                    if (hasFee == "yes")
                                    {
                                        Console.Write("Enter consultation fee amount: ");
                                        double fee = double.Parse(Console.ReadLine());
                                        billingAmount[i] += fee;
                                        visitCharges += fee;
                                    }

                                    Console.Write("Any medication charges? (yes/no): ");
                                    string hasMeds = Console.ReadLine().ToLower();

                                    if (hasMeds == "yes")
                                    {
                                        Console.Write("Enter medication charges amount: ");
                                        double meds = double.Parse(Console.ReadLine());
                                        billingAmount[i] += meds;
                                        visitCharges += meds;
                                    }

                                    if (visitCharges > 0)
                                    {
                                        Console.WriteLine("Total charges added this visit: " + visitCharges + " OMR");
                                    }
                                    else
                                    {
                                        Console.WriteLine("No charges recorded for this visit");
                                    }

                                    admitted[i] = false;
                                    assignedDoctors[i] = "";

                                    Console.WriteLine("Patient discharged successfully!");
                                }
                                else
                                {
                                    Console.WriteLine("This patient is not currently admitted");
                                }

                                break;
                            }
                        }

                        if (dischargeFound == false)
                        {
                            Console.WriteLine("Patient not found");
                        }

                        break;




                    case 4: // Search Patient
                        Console.Write("Enter Patient ID or Name: ");
                        string searchInput = Console.ReadLine();


                        bool pateintFound = false;


                        for (int i = 0; i <= lastIndex; i++)
                        {


                            if (patientNames[i] == searchInput || patientIDs[i] == searchInput)
                            {
                                pateintFound = true;
                                Console.WriteLine("----------------------------------------");
                                Console.WriteLine("Name:           " + patientNames[i]);
                                Console.WriteLine("ID:             " + patientIDs[i]);
                                Console.WriteLine("Diagnosis:      " + diagnoses[i]);
                                Console.WriteLine("Department:     " + departments[i]);
                                Console.WriteLine("Admitted:       " + admitted[i]);
                                Console.WriteLine("Total Visits:   " + visitCount[i]);
                                Console.WriteLine("Total Billing:  " + billingAmount[i] + " OMR");
                                Console.WriteLine("Doctor:         " + assignedDoctors[i]);
                                Console.WriteLine("----------------------------------------");
                                break;
                            }


                        }

                        if(pateintFound == false )
                        {
                            Console.WriteLine("Patient not found");
                        }    

                        break;






                    case 5: // List All Admitted Patients
                        Console.WriteLine("Currently Admitted Patients:");
                        Console.WriteLine("----------------------------------------");

                        bool hasAdmitted = false;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (admitted[i] == true)
                            {
                                Console.WriteLine("Name: " + patientNames[i] + " | ID: " + patientIDs[i] + " | Diagnosis: " + diagnoses[i] + " | Department: " + departments[i] + " | Doctor: " + assignedDoctors[i]);
                                hasAdmitted = true;
                            }
                        }

                        if (hasAdmitted == false)
                        {
                            Console.WriteLine("No patients currently admitted");
                        }

                        break;

                    case 6: // Transfer Patient to Another Doctor
                        Console.Write("Enter current doctor name: ");
                        string currentDoctor = Console.ReadLine();

                        Console.Write("Enter new doctor name: ");
                        string newDoctor = Console.ReadLine();

                        bool doctorFound = false;

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            if (assignedDoctors[i] == currentDoctor && admitted[i] == true)
                            {
                                doctorFound = true;
                                assignedDoctors[i] = newDoctor;
                                Console.WriteLine("Patient '" + patientNames[i] + "' has been transferred to " + newDoctor);
                            }
                        }

                        if (doctorFound == false)
                        {
                            Console.WriteLine("No admitted patients found under this doctor");
                        }

                        break;

                    case 7: // View Most Visited Patients
                        Console.WriteLine("Most Visited Patients (by visit count):");
                        Console.WriteLine("----------------------------------------");

                        int[] tempVisits = new int[100];

                        for (int i = 0; i <= lastIndex; i++)
                        {
                            tempVisits[i] = visitCount[i];
                        }

                        for (int pass = 0; pass <= lastIndex; pass++)
                        {
                            int maxIndex = 0;

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                if (tempVisits[i] > tempVisits[maxIndex])
                                {
                                    maxIndex = i;
                                }
                            }

                            Console.WriteLine("ID: " + patientIDs[maxIndex] + " | Name: " + patientNames[maxIndex] + " | Visits: " + tempVisits[maxIndex]);

                            tempVisits[maxIndex] = -1;
                        }

                        break;


                    case 8: // Search Patients by Department
                        Console.Write("Enter department name: ");
                        string searchDept = Console.ReadLine();

                        bool deptFound = false;

                        Console.WriteLine("Patients in department '" + searchDept + "':");
                        Console.WriteLine("----------------------------------------");

                        for (int i = 0; i <= lastIndex; i++)  
                        {
                            if (departments[i].ToLower() == searchDept.ToLower())
                            {
                                deptFound = true;   


                                string status = admitted[i] ? "Admitted" : "Not Admitted"; //ternary operator

                                //string stat;
                                //if (admitted[i] == true)
                                //    stat = "admitted";
                                //else
                                //    stat = "not admitted";


                                Console.WriteLine("ID: " + patientIDs[i] + " | Name: " + patientNames[i] + " | Diagnosis: " + diagnoses[i] + " | Status: " + status);
                            }
                        }

                        if (deptFound == false)
                        {
                            Console.WriteLine("No patients found in this department");
                        }

                        break;

                    case 9: // Billing Report
                        Console.WriteLine("Billing Report:");
                        Console.WriteLine("1. System-wide total");
                        Console.WriteLine("2. Individual patient");
                        Console.Write("Choose option: ");
                        int billingOption = int.Parse(Console.ReadLine());

                        if (billingOption == 1)
                        {
                            double totalBilling = 0;

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                totalBilling += billingAmount[i];
                            }

                            Console.WriteLine("----------------------------------------");
                            Console.WriteLine("Total billing collected: " + totalBilling + " OMR");
                        }
                        else if (billingOption == 2)
                        {
                            Console.Write("Enter Patient ID or Name: ");
                            string billingInput = Console.ReadLine();

                            bool billingFound = false;

                            for (int i = 0; i <= lastIndex; i++)
                            {
                                if (patientNames[i] == billingInput || patientIDs[i] == billingInput)
                                {
                                    billingFound = true;
                                    Console.WriteLine("----------------------------------------");
                                    Console.WriteLine("Billing for " + patientNames[i] + ": " + billingAmount[i] + " OMR");
                                    break;
                                }
                            }

                            if (billingFound == false)
                            {
                                Console.WriteLine("No billing records found for this patient");
                            }
                        }

                        break;

                    case 10: // Exit
                        Console.WriteLine("Exiting system...");
                        Console.WriteLine("Thank you for using the Healthcare Management System!");
                        Console.WriteLine("----------------------------------------");
                        exit = true;
                        break;

                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }

                Console.WriteLine("Press any key to continue...");
                Console.ReadKey();
                Console.Clear();
            }
        }
    }
}


/*
 
1- Error Handling
2- input validation

*/
