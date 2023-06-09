using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ART
{
    public partial class Form1 : Form
    {
        List<Park> parks = new List<Park>() //Sekce, která je zodpovědná za data, která jsou v tabulce
        {
            new Park("Pechersk",
                new List<Car>{
                    new Car("Transit","Praha-Brno",22,6),
                    new Car("Fiat","Praha-Olomouc",10,4)

                }),
            new Park("Lisova",
                new List<Car>{
                     new Car("Transit","Praha-Brno-Budějovice",30,8),
                     new Car("Skoda Octavia","Praha-Krumlov",50,4)
                })

        };
        List<User> users = new List<User>() // Blok zodpovědný za uživatele
        {
            new User("Admin","0000",EAccess.Admin,1000),
            new User("Dasha","123",EAccess.User,1000)
        };

                       //Blok vytváření interakce s uživatelem
        Form form = new Form();
        Button button;
        ComboBox cB;

        Label l1 = new Label();
        Label l2 = new Label();
        Label l3 = new Label();
        Label l4 = new Label();
        Label l5 = new Label();

        ComboBox t1 = new ComboBox();
        TextBox t2 = new TextBox();
        TextBox t3 = new TextBox();
        TextBox t4 = new TextBox();
        TextBox t5 = new TextBox();


        Form checkAccaunt = new Form();
        Label nam = new Label();
        Label pas = new Label();
        TextBox userName = new TextBox();
        TextBox password = new TextBox();
        Button send;
        Button registration;
        string accessUser = "";

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)// Blok, který je zodpovědný za interakci s novými nabídkami na trhu
        {

            //users =JsonSeralizer.DesarilizatorLoadUser();
          //  parks =JsonSeralizer.DesarilizatorLoadPark();

            userName.Text =null;
            password.Text =null;

            foreach (var item in parks)
            {
                comboBox1.Items.Add(item.Name);
            }
            comboBox2.Items.Add("Add Car");
            comboBox2.Items.Add("Delete Car");
            comboBox2.Items.Add("Purchased tickets");



// Blokování registrace uživatele            
            nam.Text ="User Name:";
            nam.Location= new Point(50, 50);

            pas.Text="Password:";
            pas.Location= new Point(50, 80);

            userName.Location=new Point(120, 50);

            password.Location=new Point(120, 80);

            send= new Button();
            send.Location= new Point(100, 120);
            send.Text="Login";
            send.Click +=checkUser;

            registration=new Button();
            registration.Text="Registration";
            registration.Location= new Point(90, 160);
            registration.Width=100;
            registration.Click+=registrationUser;



            checkAccaunt.Controls.Add(userName);
            checkAccaunt.Controls.Add(password);
            checkAccaunt.Controls.Add(nam);
            checkAccaunt.Controls.Add(pas);
            checkAccaunt.Controls.Add(send);
            checkAccaunt.Controls.Add(registration);
            checkAccaunt.ShowDialog();

            this.Visible=false;
        }
        void RefreshGrid(Park park)
{ // Sloupce s názvy proměnných, které se zobrazují ve formuláři
            dataGridView1.ColumnCount=1;
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 5;
            dataGridView1.RowCount = park.Cars.Count + 1;
            dataGridView1.Columns[0].HeaderCell.Value = "id";
            dataGridView1.Columns[1].HeaderCell.Value = "Model";
            dataGridView1.Columns[2].HeaderCell.Value = "Price";
            dataGridView1.Columns[3].HeaderCell.Value = "How much seats";
            dataGridView1.Columns[4].HeaderCell.Value = "Route";

            for (int i = 0; i < park.Cars.Count; i++)
            {
                dataGridView1.Rows[i].Cells[0].Value = i + 1;
                dataGridView1.Rows[i].Cells[1].Value = park.Cars[i].Model;
                dataGridView1.Rows[i].Cells[2].Value = park.Cars[i].Price;
                dataGridView1.Rows[i].Cells[3].Value = park.Cars[i].NumberOfSeats;
                dataGridView1.Rows[i].Cells[4].Value = park.Cars[i].Route;


            }
            //JsonSeralizer.SeralizatorSaveUser(users);
            JsonSeralizer.SeralizatorSavePark(parks);
        }
        void ShowBuyTicket() //Blok zodpovědný za nákup vstupenek
         {
            int count = 0;
            foreach (var item in users)
            {
                foreach (var item2 in item.Ticket)
                {
                    count++;
                }
            }
            dataGridView1.ColumnCount=1;
            dataGridView1.Rows.Clear();
            dataGridView1.ColumnCount = 7;
            dataGridView1.RowCount = count + 1;
            dataGridView1.Columns[0].HeaderCell.Value = "id";
            dataGridView1.Columns[1].HeaderCell.Value = "Buyer";
            dataGridView1.Columns[2].HeaderCell.Value = "Park";
            dataGridView1.Columns[3].HeaderCell.Value = "Model";
            dataGridView1.Columns[4].HeaderCell.Value = "Route";
            dataGridView1.Columns[5].HeaderCell.Value = "How much seats";
            dataGridView1.Columns[6].HeaderCell.Value = "Paid";

            int i = 0;
            foreach (var item in users)
            {
                foreach (var item2 in item.Ticket)
                {
                    dataGridView1.Rows[i].Cells[0].Value = i + 1;
                    dataGridView1.Rows[i].Cells[1].Value = item.Name;
                    dataGridView1.Rows[i].Cells[2].Value = item2.Park;
                    dataGridView1.Rows[i].Cells[3].Value = item2.Model;
                    dataGridView1.Rows[i].Cells[4].Value = item2.Route;
                    dataGridView1.Rows[i].Cells[5].Value = item2.CountOfSeats;
                    dataGridView1.Rows[i].Cells[6].Value = item2.Cost+" czk";
                    i++;
                }

            }
                



            
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            var park = (string)((ComboBox)sender).SelectedItem;
            foreach (var item in parks)
            {
                if (item.Name.Equals(park))
                {
                    RefreshGrid(item);
                    break;
                }
            }

        }
               // Blok zodpovědný za přidávání nových strojů do programu
        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
           var change =  (string)((ComboBox)sender).SelectedItem;
            if (accessUser.Equals(EAccess.Admin.ToString()))
            {
                switch (change)
                {
                    case "Add Car":

                        form.Controls.Clear();
                        button = new Button();
                        button.Text = "Add";
                        button.Location = new Point(100, 220);
                        button.Click+=addCar;


                        l1.Text = "Park:";
                        l1.Location = new Point(20, 60);

                        l2.Text="Model:";
                        l2.Location= new Point(20, 90);


                        l3.Text="Price by ticet:";
                        l3.Location= new Point(20, 120);

                        l4.Text = "How much seats:";
                        l4.Location=new Point(20, 150);

                        l5.Text = "Route:";
                        l5.Location=new Point(20, 180);

                        t1.Location=new Point(120, 60);
                        t1.Items.Clear();
                        foreach (var item in parks)
                        {
                            t1.Items.Add(item.Name);
                        }

                        t2.Location=new Point(120, 90);

                        t3.Location=new Point(120, 120);

                        t4.Location=new Point(120, 150);

                        t5.Location = new Point(120, 180);
                        t5.Text = "Example: Prague-Brno-Olomouc";

                        form.Controls.Add(t1);
                        form.Controls.Add(t2);
                        form.Controls.Add(t3);
                        form.Controls.Add(t4);
                        form.Controls.Add(t5);
                        form.Controls.Add(l1);
                        form.Controls.Add(l2);
                        form.Controls.Add(l3);
                        form.Controls.Add(l4);
                        form.Controls.Add(l5);
                        form.Controls.Add(button);

                        form.ShowDialog();

                        break;
                    case "Delete car":

                        form.Controls.Clear();
                        cB= new ComboBox();
                        cB.Items.Clear();
                        l3.Text="Choose car:";
                        l3.Width=150;
                        l3.Location= new Point(70, 90);
                        cB.Location=new Point(20, 120);
                        cB.Width=250;
                        foreach (var item in parks)
                        {
                            foreach (var car in item.Cars)
                            {
                                cB.Items.Add(item.Name+":"+car.Model+" "+car.Route);
                            }
                        }
                        cB.SelectedIndexChanged +=deleteCar;
                        cB.DropDownStyle=ComboBoxStyle.DropDownList;

                        form.Controls.Add(cB);
                        form.Controls.Add(l3);

                        form.ShowDialog();
                        break;
                    case "Purchased tikets":
                        ShowBuyTicket();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Sorry you do not have access(");
            }
        }
        private void deleteCar(object s,EventArgs e) // Blok s výběrem míst
        {
            Park printPark = new Park();
            var delete =  (string)((ComboBox)s).SelectedItem;
            foreach(var item in parks)
            {
                foreach (var car in item.Cars)
                {
                    if (delete.Equals(item.Name+":"+car.Model+" "+car.Route))
                    {
                        printPark=item;
                        item.Cars.Remove(car);
                        break;
                    }
                }
            }
            comboBox1.Items.Clear();
            Park del=new Park();
            foreach (var item in parks)
            {
                if (item.Cars.Count==0)
                    del=item;
                else
                    comboBox1.Items.Add(item.Name);
            }
            if ( del.Cars!=null  && del.Cars.Count==0)
            {
                parks.Remove(del);
            }
            RefreshGrid(printPark);
            form.Close();
        }
        private void addCar(object s , EventArgs e)
        {
            try
            {
                int check = 0;
                foreach (var item in parks)
                {
                    if (item.Name.Equals((string)t1.SelectedItem))
                    {
                        check++;
                        item.Cars.Add(new Car(t2.Text, t5.Text, int.Parse(t3.Text), int.Parse(t4.Text)));
                        RefreshGrid(item);
                        break;

                    }
                }
                if (check == 0)
                {
                    parks.Add(new Park((string)t1.SelectedItem, new List<Car> { new Car(t2.Text, t5.Text, int.Parse(t3.Text), int.Parse(t4.Text)) }));
                    RefreshGrid(parks[parks.Count-1]);
                }

                form.Close();
            }
            catch (Exception)
            {

                MessageBox.Show("Fill in the fields correctly!\n(Where the number of seats and the price should be numbers)");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            var text = ((Button)sender).Text; // Vstupní a výstupní bloky pro vyvážení výstupu a administrační panel

            switch (text)
            {
               
                case "Exit":
                    button1.Text="Login";
                    label3.Text="";
                    password.Text=null;
                    userName.Text=null;
                    accessUser="";
                    break;
            }
            

        }
        private void checkUser(object s ,EventArgs e)
        {
            int check = 0;
            foreach (var item in users)
            {
                if (item.Name.Equals(userName.Text) && item.Password.Equals(password.Text))
                {
                    check++;
                    button1.Text="Exit";
                    label3.Text=userName.Text;
                    accessUser=item.Access.ToString();
                    checkAccaunt.Close();
                    label4.Text="Balance:"+item.Balans;
                    if (label3.Text.Equals("Admin"))
                    {
                        button2.Visible=false;
                        label2.Visible=false;
                        comboBox2.Visible=false;
                        button3.Visible=false;
                    }
                    else
                    {
                        button3.Visible=true;
                        button2.Visible=true;
                        label2.Visible=true;
                        comboBox2.Visible=true;
                    }
                    this.Visible=true;
                }
            }
            if(check == 0)
            {
                MessageBox.Show("Your password or username is incorrect!\n(You may need to register, please enter your details\n" +
                     "and click on 'Registration')");
            }
        }
        private void registrationUser(object s,EventArgs e)
        {
            users.Add(new User(userName.Text, password.Text, EAccess.User,1000));// Chybový výstup, pokud osoba nebyla zaregistrována v programu
            foreach (var item in users)
            {
                if (item.Name.Equals(userName.Text) && item.Password.Equals(password.Text))
                {
                    button1.Text="Exit";
                    label3.Text=userName.Text;
                    accessUser=item.Access.ToString();
                    button2.Visible=true;
                    label2.Visible=true;
                    comboBox2.Visible=true;
                    button3.Visible=true;
                    checkAccaunt.Close();
                }
            }
                MessageBox.Show("Good afternoon "+userName.Text+"\nYou have successfully registered!");
        }

        private void button2_Click(object sender, EventArgs e)// Samotný systém nákupu vstupenek
        {

            form.Controls.Clear();
            cB= new ComboBox();
            cB.Items.Clear();

            l1.Text="Enter the number of seats:";
            l1.Location = new Point(70, 30);
            l1.Width=150;
            t2.Text="";
            t2.Location=new Point(90, 60);

            l3.Text="Choose car:";
            l3.Width=150;
            l3.Location= new Point(70, 90);
            cB.Location=new Point(20, 120);
            cB.Width=250;
            foreach (var item in parks)
            {
                foreach (var car in item.Cars)
                {
                    cB.Items.Add(item.Name+":"+car.Model+" "+car.Route);
                }
            }
            
            cB.SelectedIndexChanged +=BuyTicket;
            cB.DropDownStyle=ComboBoxStyle.DropDownList;

            form.Controls.Add(cB);
            form.Controls.Add(l3);
            form.Controls.Add(l1);
            form.Controls.Add(t2);
            form.ShowDialog();
        }
        private void BuyTicket(object s,EventArgs e)
        {
            var ticket = (string)((ComboBox)s).SelectedItem;
            try
            {

                foreach (var item in parks)
                {
                    foreach (var car in item.Cars)
                    {
                        if (ticket.Equals(item.Name+":"+car.Model+" "+car.Route)) // Blok s chybovým výstupem o nedostatečném počtu míst
                        {
                            if (int.Parse(t2.Text)>car.NumberOfSeats)
                            {
                                if (car.NumberOfSeats==0)
                                {
                                    MessageBox.Show("Places are sold out"); 
                                }
                                else
                                {
                                    MessageBox.Show("Not enough seats, please enter a smaller number ");
                                }
                            }
                            else
                            {
                                int check = 0;
                                foreach (var user in users)
                                {
                                    if(userName.Text.Equals(user.Name) && password.Text.Equals(user.Password))
                                    {
                                        check++;
                                        user.Ticket.Add(new Ticket(item.Name, car.Model, car.Route, car.Price*int.Parse(t2.Text), int.Parse(t2.Text)));
                                        MessageBox.Show("You have purchased "+t2.Text+"\nPaid: "+ car.Price*int.Parse(t2.Text)+" czk");
                                        car.NumberOfSeats-=int.Parse(t2.Text);
                                        user.Balans-=car.Price*int.Parse(t2.Text);
                                        label4.Text="Balans:"+user.Balans;

                                    }
                                }

                                if (check==0)
                                {
                                    MessageBox.Show("You are not logged in!");
                                }
                                form.Close();

                            }
                            RefreshGrid(item);
                            break;
                        }
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Fill in all fields correctly!");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (var item in users)
            {
                if (item.Name.Equals(label3.Text))
                {
                    string tik = "";
                    foreach (var t in item.Ticket)
                    {
                        tik+=t.ToString();
                    }
                    MessageBox.Show(tik);
                }
            }
        }
    }
}
