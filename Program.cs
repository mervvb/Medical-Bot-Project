using System;
public class MedicalBot
{
    public const string BotName = "Bob";

    public static string GetBotName(string text)
    {
        text = BotName;
        return text;
    }
    public void PrescribeMedication(Patient patient)
    {

        if (patient.GetSymptomCode() == "Headache")
        {
            patient.SetPrescription("ibuprofen" + GetDosage("ibuprofen"));
        }
        else if (patient.GetSymptomCode() == "Skin rashes")
        {
            patient.SetPrescription("diphenhydramine" + GetDosage("diphenhydramine"));
        }
        else if (patient.GetSymptomCode() == "Dizziness")
        {
            if (patient.GetMedicalHistory() == "diabetes" || patient.GetMedicalHistory() == "Diabetes")
            {
                patient.SetPrescription("metformin" + GetDosage("metformin"));
            }
            else
            {
                patient.SetPrescription("dimenhydrinate" + GetDosage("dimenhydrinate"));
            }
        }

        string GetDosage(string medicineName)
        {

            if (medicineName == "ibuprofen")
            {
                if (patient.GetAge() < 18)
                {

                    return " and the dosage is 400 mg";
                }
                else
                {

                    return " and the dosage is 800 mg";
                }
            }
            else if (medicineName == "diphenhydramine")
            {
                if (patient.GetAge() < 18)
                {

                    return " and the dosage is 50 mg";
                }
                else
                {

                    return " and the dosage is 300 mg";
                }

            }
            else if (medicineName == "metformin")
            {

                return " and the dosage is 500 mg";
            }
            else
            {
                return " unknown";
            }

        }
    }

}
public class Patient
{
    public string name;
    public int age;
    public string gender;
    public string medicalHistory;
    public string symptomCode;
    public string prescription;
    public bool SetName(string name, out string errorMessage)
    {
        bool isNameValid;

        // empty
        if (name == null || name.Length == 0)
        {
            isNameValid = false;
            errorMessage = "Patient name can't be empty";
            return isNameValid;
        }

        //one character
        else if (name.Length == 1)
        {
            isNameValid = false;
            errorMessage = "Patient name should contain at least two or more characters";
            return isNameValid;
        }

        // Name is valid
        isNameValid = true;
        errorMessage = "";

        this.name = name;
        return isNameValid;
    }

    public string GetName()
    {

        return name;
    }
    public bool SetAge(int age, out string errorMessage)
    {
        bool isAgeValid;
        if (age < 0)
        {
            isAgeValid = false;
            errorMessage = "Patient age cannot be negative.";
            return isAgeValid;
        }
        else if (age > 100)
        {
            isAgeValid = false;
            errorMessage = "Patient age cannot be bigger than 100.";
            return isAgeValid;
        }
        isAgeValid = true;
        errorMessage = "";
        this.age = age;
        return isAgeValid;

    }
    public int GetAge()
    {
        return age;
    }
    public bool SetGender(string gender, out string errorMessage)
    {
        bool isValidGender;
        if (gender == null)
        {
            isValidGender = false;
            errorMessage = "Patient gender cannot be empty.";
            return isValidGender;
        }
        else if (gender == "Male" || gender == "male")
        {
            isValidGender = true;
            errorMessage = "";
            return isValidGender;
        }
        else if (gender == "Female" || gender == "female")
        {
            isValidGender = true;
            errorMessage = "";
            return isValidGender;
        }
        isValidGender = false;
        errorMessage = "";
        this.gender = gender;
        return isValidGender;
    }
    public string GetGender()
    {
        return gender;
    }
    public void SetMedicalHistory(string medicalHistory)
    {
       this.medicalHistory = medicalHistory;
    }
    public string GetMedicalHistory()
    {
        return medicalHistory;
    }
    public bool SetSymptomCode(string symptomCode, out string errorMessage)
    {
        this.symptomCode = symptomCode;
        bool isValidSymptom;
        if (symptomCode == "S1" || symptomCode == "s1")
        {
            isValidSymptom = true;
            errorMessage = "";
            return isValidSymptom;
        }
        else if (symptomCode == "S2" || symptomCode == "s2")
        {
            isValidSymptom = true;
            errorMessage = "";
            return isValidSymptom;
        }
        else if (symptomCode == "S3" || symptomCode == "s3")
        {
            isValidSymptom = true;
            errorMessage = "";
            return isValidSymptom;
        }
        else
        {
            errorMessage = "You should enter valid symptom code.";
            return false;
        }

    }
    public string GetSymptomCode()
    {
        string symptom = "unknown";
        if (symptomCode == "s1" || symptomCode == "S1")
        {
            symptom = "Headache";
            return symptom;
        }
        else if (symptomCode == "s2" || symptomCode == "S2")
        {
            symptom = "Skin rashes";
            return symptom;
        }
        else if (symptomCode == "s3" || symptomCode == "S3")
        {
            symptom = "Dizziness";
            return symptom;
        }
        else
        {
            return symptom;
        }

    }
    public void SetPrescription(string prescription)
    {
        this.prescription = prescription;
    }
    public string GetPrescription()
    {
        return prescription;
    }
}



class Program
{
    static void Main()
    {
        MedicalBot bot = new MedicalBot();
        Patient patient = new Patient();
        Console.WriteLine("Hi, I'm " + MedicalBot.BotName + " I'm here to help you in your medication.");
        Console.WriteLine("Enter your(patient) details: ");
        Console.Write("Enter a Name: ");
        while (!patient.SetName(Console.ReadLine(), out string errorMessage))
        {
            Console.WriteLine(errorMessage);
            Console.Write("Enter valid name: ");
        }

        Console.Write("Enter a Age: ");
        while (!patient.SetAge(int.Parse(Console.ReadLine()), out string errorMessage))
        {
            Console.WriteLine(errorMessage);
            Console.Write("Enter a valid age: ");
        }

        Console.Write("Enter a gender: ");
        while (!patient.SetGender(Console.ReadLine(), out string errorMessage))
        {
            Console.WriteLine(errorMessage);
            Console.Write("Enter valid gender: ");
        }

        Console.Write("Please fill this if you have illness or press Enter for None: ");
        patient.SetMedicalHistory(Console.ReadLine());

        Console.WriteLine("Welcome " + patient.GetName());
        Console.WriteLine("S1. Headache");
        Console.WriteLine("S2. Skin rashes");
        Console.WriteLine("S3. Dizziness");
        Console.Write("Enter the symptom code from above list (S1, S2 or S3): ");
        while (!patient.SetSymptomCode(Console.ReadLine(), out string errorMessage))
        {
            Console.WriteLine(errorMessage);
            Console.Write("Enter the symptom code from above list (S1, S2 or S3): ");
        }
        bot.PrescribeMedication(patient);
        Console.WriteLine("\nYour prescription based on your age, symptoms and medical history: " + patient.GetPrescription());

        Console.WriteLine("\nThank you for coming.");

        Console.ReadLine();
    }

}
