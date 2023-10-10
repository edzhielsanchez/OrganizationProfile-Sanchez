using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace OrganizationProfile
{
    public partial class frmRegistration : Form
    {
        private string _FullName;
        private int _Age;
        private long _ContactNo;
        private long _StudentNo;

        public frmRegistration()
        {
            InitializeComponent();
        }

        public long StudentNumber(string studNum)
        {
            try
            {
                _StudentNo = long.Parse(studNum);
            }
            catch (OverflowException o)
            {
                MessageBox.Show("Overflow Exception Message for Student Number: " + o.Message);
            }
            catch (ArgumentNullException a)
            {
                MessageBox.Show("Argument Null Exception Message for Student Number: " + a.Message);
            }
            catch (IndexOutOfRangeException i)
            {
                MessageBox.Show("Index Out of Range Exception Message for Student Number: " + i.Message);
            }
            catch (FormatException f)
            {
                _StudentNo = 0;
                MessageBox.Show("Format Exception Message for Student Number: " + f.Message);
            }
            finally
            {

            }

            return _StudentNo;
        }

        public long ContactNo(string Contact)
        {
            try
            {
                if (Regex.IsMatch(Contact, @"^[0-9]{10,11}$"))
                {
                    _ContactNo = long.Parse(Contact);
                }
                else
                {
                    throw new FormatException("Invalid contact number format");
                }
            }
            catch (OverflowException o)
            {
                MessageBox.Show("Overflow Exception Message for Contact Number: " + o.Message);
            }
            catch (ArgumentNullException a)
            {
                MessageBox.Show("Argument Null Exception Message for Contact Number: " + a.Message);
            }
            catch (IndexOutOfRangeException i)
            {
                MessageBox.Show("Index Out of Range Exception Message for Contact Number: " + i.Message);
            }
            catch (FormatException f)
            {
                _ContactNo = 0;
                MessageBox.Show("Format Exception Message for Contact Number: " + f.Message);
            }
            finally
            {

            }

            return _ContactNo;
        }

        public string FullName(string LastName, string FirstName, string MiddleInitial)
        {
            try
            {
                if (Regex.IsMatch(LastName, @"^[a-zA-Z]+$") || Regex.IsMatch(FirstName, @"^[a-zA-Z]+$") || Regex.IsMatch(MiddleInitial, @"^[a-zA-Z]+$"))
                {
                    _FullName = LastName + ", " + FirstName + ", " + MiddleInitial;
                }
                else
                {
                    throw new FormatException("Invalid name format");
                }
            }
            catch (OverflowException o)
            {
                MessageBox.Show("Overflow Exception Message for Full Name: " + o.Message);
            }
            catch (ArgumentNullException a)
            {
                MessageBox.Show("Argument Null Exception Message for Full Name: " + a.Message);
            }
            catch (IndexOutOfRangeException i)
            {
                MessageBox.Show("Index Out of Range Exception Message for Full Name: " + i.Message);
            }
            catch (FormatException f)
            {
                _FullName = "";
                MessageBox.Show("Format Exception Message for Full Name: " + f.Message);
            }
            finally
            {

            }

            return _FullName;
        }

        public int Age(string age)
        {
            try
            {
                if (Regex.IsMatch(age, @"^[0-9]{1,3}$"))
                {
                    _Age = Int32.Parse(age);
                }
                else
                {
                    throw new FormatException("Invalid age format");
                }
            }
            catch (OverflowException o)
            {
                MessageBox.Show("Overflow Exception Message for Age: " + o.Message);
            }
            catch (ArgumentNullException a)
            {
                MessageBox.Show("Argument Null Exception Message for Age: " + a.Message);
            }
            catch (IndexOutOfRangeException i)
            {
                MessageBox.Show("Index Out of Range Exception Message for Age: " + i.Message);
            }
            catch (FormatException f)
            {
                _Age = 0;
                MessageBox.Show("Format Exception Message for Age: " + f.Message);
            }
            finally
            {

            }

            return _Age;
        }

        private void frmRegistration_Load(object sender, EventArgs e)
        {
            string[] ListOfProgram = new string[]{
             "BS Information Technology",
             "BS Computer Science",
             "BS Information Systems",
             "BS in Accountancy",
             "BS in Hospitality Management",
             "BS in Tourism Management"
             };

            for (int i = 0; i < 6; i++)
            {
                cbPrograms.Items.Add(ListOfProgram[i].ToString());
            }

            string[] ListOfGender = new string[]{
             "Male",
             "Female",
             "Pefer not to say"
             };

            for (int gender = 0; gender < 3; gender++)
            {
                cbGender.Items.Add(ListOfGender[gender].ToString());
            }
        }

        private void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                StudentInformationClass.SetFullName = FullName(txtLastName.Text, txtFirstName.Text, txtMiddleInitial.Text);
                StudentInformationClass.SetStudentNo = StudentNumber(txtStudentNo.Text);
                StudentInformationClass.SetProgram = cbPrograms.Text;
                StudentInformationClass.SetGender = cbGender.Text;
                StudentInformationClass.SetContactNo = ContactNo(txtContactNo.Text);
                StudentInformationClass.SetAge = Age(txtAge.Text);
                StudentInformationClass.SetBirthDay = datePickerBirthday.Value.ToString("yyyy-MM-dd");

                frmConfirmation frm = new frmConfirmation();
                frm.ShowDialog();
            }
            catch (FormatException f)
            {
                MessageBox.Show("Invalid format: " + f.Message);
            }
            catch (ArgumentException a)
            {
                MessageBox.Show("Invalid argument: " + a.Message);
            }
            catch (OverflowException o)
            {
                MessageBox.Show("Value is too large: " + o.Message);
            }
            catch (IndexOutOfRangeException i)
            {
                MessageBox.Show("Index out of range: " + i.Message);
            }
        }
    }
}
