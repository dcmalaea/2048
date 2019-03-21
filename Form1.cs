using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace _2048
{
    public partial class Form1 : Form
    {

        int[,] Grid = new int[7,7];
        int[,] GridCopy = new int[7, 7];
        int [] Vector = new int[100];
        int Score = 0;
        public Form1()
        {
            InitializeComponent();
        }
        private void Bordare()
        {   //bordeaza matricea cu -1;
            for (int i = 0; i <= 5; i++) //Bordare cu -1
            {
                Grid[0, i] = -1;
                Grid[i, 0] = -1;
                Grid[5, i] = -1;
                Grid[i, 5] = -1;
            }
        }
        private void GridToLabels()
        {
            int TagCounter=0;
            for(int i=1;i<=4;i++)
                for(int j=1;j<=4;j++)
                {
                    TagCounter++; //tag-urile labelurilor sunt de la 1 la 16 in ordinea parcurgerii
                    foreach(Label label in  this.Controls)
                    {   
                        int tag = Convert.ToInt32(label.Tag);
                        if(tag==TagCounter)
                        {
                            if (Grid[i, j] == 0) //daca un el e zero nu se afiseaza nimic
                            {
                                label.Text = " ";
                                label.BackColor = System.Drawing.Color.White;
                            }
                            else if(Grid[i,j]==2) //Color coding ^_^
                            {
                                label.Text = Convert.ToString(Grid[i, j]);
                                label.BackColor = System.Drawing.Color.LightGray;
                            }
                            else if (Grid[i, j] == 4)
                            {
                                label.Text = Convert.ToString(Grid[i, j]);
                                label.BackColor = System.Drawing.Color.MediumPurple;
                            }
                            else if (Grid[i, j] == 8)
                            {
                                label.Text = Convert.ToString(Grid[i, j]);
                                label.BackColor = System.Drawing.Color.LightSalmon;
                            }
                            else if (Grid[i, j] == 16)
                            {
                                label.Text = Convert.ToString(Grid[i, j]);
                                label.BackColor = System.Drawing.Color.Salmon;
                            }
                            else if (Grid[i, j] == 32)
                            {
                                label.Text = Convert.ToString(Grid[i, j]);
                                label.BackColor = System.Drawing.Color.DarkSalmon;
                            }
                            else if (Grid[i, j] == 64)
                            {
                                label.Text = Convert.ToString(Grid[i, j]);
                                label.BackColor = System.Drawing.Color.Orange;
                            }
                            else if (Grid[i, j] == 128)
                            {
                          
                                label.Text = Convert.ToString(Grid[i, j]);
                                label.BackColor = System.Drawing.Color.DarkOrange;
                            }
                            else if (Grid[i, j] == 256)
                            {
                                label.Text = Convert.ToString(Grid[i, j]);
                                label.BackColor = System.Drawing.Color.OrangeRed;
                            }
                            else if (Grid[i, j] == 612)
                            {
                                label.Text = Convert.ToString(Grid[i, j]);
                                label.BackColor = System.Drawing.Color.Red;
                            }
                            else if (Grid[i, j] == 1024)
                            {
                                label.Text = Convert.ToString(Grid[i, j]);
                                label.BackColor = System.Drawing.Color.DarkRed;
                            }
                            else if (Grid[i, j] == 2048)
                            {
                                label.Text = Convert.ToString(Grid[i, j]);
                                label.BackColor = System.Drawing.Color.Purple; 
                            } 
                            else
                            {
                                label.Text = Convert.ToString(Grid[i, j]);
                                label.BackColor = System.Drawing.Color.LightGreen;
                            }
                        }
                    }

                }
        }
        private void AddRandom()
        {   //verifica care sunt el = 0 si retine perechile de coordonate ale respectivului element
            int TagCounter=0;
            for (int i = 1; i <= 99; i++) //se initializeaza cu 0 vectorul
                Vector[i] = 0; 
            int PositionCounter = 0;
            for(int i=1;i<=4;i++)
                for(int j=1;j<=4;j++)
                {
                    if(Grid[i,j]==0&&(Grid[i-1,j]>0||Grid[i+1,j]>0||Grid[i,j+1]>0||Grid[i,j-1]>0)) //daca el = 0 si are cel putin un vecin
                    {
                        PositionCounter= PositionCounter + 2;
                        Vector[PositionCounter - 1] = i; //pe prima pozitie se retine linia
                        Vector[PositionCounter] = j; //pe a doua pozitie se retine coloana
                    }
                }
            Random r = new Random(); 
            int rInt = r.Next(1, PositionCounter+1); // se alege o pozitie random din vector
            if(rInt%2==0) //daca poz e div cu 2 inseamna ca e poz unei coloane deci poz-1 e pozitia liniei
            {
                Grid[Vector[rInt - 1], Vector[rInt]] = 2; //se adauga 2 la acele coordonate
                for (int i = 1; i <= 4; i++)       //SCHIMBA CULOAREA LABELULUI UNDE S-A ADAUGAT NUMARUL
                    for (int j = 1; j <= 4; j++)
                    {
                        TagCounter++;
                        if (i ==Vector[ rInt-1 ]&& j == Vector[rInt])
                        {
                            foreach (Label label in this.Controls)
                            {
                                if (TagCounter == Convert.ToInt32(label.Tag))
                                {
                                    label.BackColor = System.Drawing.Color.LightBlue;
                                    label.Text = Convert.ToString(Grid[i, j]);
                                }
                            }
                        }
                    }
            }
            if (rInt % 2 != 0) //daca poz nu e div cu 2 inseamna ca e poz unei linii deci poz+1 e pozitia coloanei
            {
                Grid[Vector[rInt], Vector[rInt+1]] = 4; //se adauga 4 la acele coordonate
                for (int i = 1; i <= 4; i++)   //SCHIMBA CULOAREA LABELULUI UNDE S-A ADAUGAT NUMARUL
                    for (int j = 1; j <= 4; j++)
                    {
                        TagCounter++;
                        if (i == Vector[rInt] && j == Vector[rInt + 1])
                        {
                            foreach (Label label in this.Controls)
                            {
                                if (TagCounter == Convert.ToInt32(label.Tag))
                                {
                                    label.BackColor = System.Drawing.Color.LightBlue;
                                    label.Text = Convert.ToString(Grid[i, j]);
                                }
                            }
                        }
                    }
            }
          
                    
       

        }
        private void CreateGridCopy()
        {
            for (int i = 1; i <= 4; i++)
                for (int j = 1; j <= 4; j++)
                    GridCopy[i, j] = Grid[i, j];
            //creeaza o matrice copie a celei initiale
        }
        private Boolean  GridCheck()
        {  //verifica daca matricea s-a modificat in urma executarii unei algoritm de introducere a unei comenzi
           
            for (int i = 1; i <= 4; i++)
                for (int j = 1; j <= 4; j++)
                    if (GridCopy[i, j] != Grid[i, j])
                        return false;
           return true;
        } 
        private void InitializeGride()
        {
            for (int i = 1; i <= 4; i++) //initializeaza matricea cu 0;
                for (int j = 1; j <= 4; j++)
                    Grid[i, j] = 0; 
            Random r = new Random();
            int rInt = r.Next(1, 5);
            Random r2 = new Random();
            int rInt2 = r.Next(1, 5);
            Grid[rInt, rInt2] = 2; //se genereaza pozitia primului element care e mereu 2
        }
        private Boolean  MovesPossible() //Verificare daca mai sunt miscari posibile
        {
            for(int i=1;i<=4;i++)
                for (int j = 1; j <= 4; j++)
                {
                    if (Grid[i, j] == 0) //daca exista spatii libere
                        return true;
                    if (Grid[i, j] == Grid[i - 1, j] || Grid[i, j] == Grid[i + 1, j] || Grid[i, j] == Grid[i, j - 1] || Grid[i, j] == Grid[i, j + 1])
                    {  
                        //daca exista vecini cu aceeasi valoare
                        return true;
                    }
                }
            return false;
        }
        private void WKey()
        {   
            int line;
            for(int i=2;i<=4;i++) //parcurgere matrice
                for(int j=1;j<=4;j++)
                  {
                    if(Grid[i,j]!=0) 
                    {
                        if (Grid[i - 1, j] == 0) //daca el anterior e nul
                        {
                            line = i - 1;
                            while(Grid[line,j]==0)  //devansam pana gasim un el
                            {
                                line--;
                            }
                            if(line>0 && Grid[i,j]==Grid[line,j]) //daca el gasit e egal cu cel initial
                            {
                                Grid[i, j] = 0; // el initial devine nul 
                                Grid[line, j] =  Grid[line, j] * -2; //el gasit se inmulteste cu 2 si  cu -1 pentru a nu se repeta operatia;
                                Score = Score + Grid[line, j] * -1;
                            }
                            else if(line>0 && Grid[i,j]!=Grid[line,j]) //daca exista elemente nule intre 2 el diferite
                            {
                                Grid[line + 1, j] = Grid[i, j]; 
                                Grid[i, j] = 0;
                            }
                            else if(line==0) //daca toate el sunt nule
                            {
                                Grid[line + 1, j] = Grid[i, j];
                                Grid[i, j] = 0;
                            }
                        }
                        else if(Grid[i,j] == Grid[i-1,j]) //daca el sunt egale
                        {
                            Grid[i, j] = 0;
                            Grid[i - 1, j] = Grid[i - 1, j] * -2;
                            Score = Score + Grid[i-1, j] * -1;
                        }                       
                    }
                  }
            for (int i = 1; i <= 4; i++) //el inmultite cu -1 sunt puse in modul;
                for (int j = 1; j <= 4; j++)
                    if (Grid[i, j] < 0) Grid[i, j] = Grid[i, j] - 2 * Grid[i, j];
        }
        private void SKey()
        {
            int line;
            for (int i = 3; i >=1; i--) //parcurgere matrice
                for (int j = 1; j <= 4; j++)
                {
                    if (Grid[i, j] != 0)
                    {
                        if (Grid[i + 1, j] == 0) //daca el anterior e nul
                        {
                            line = i;
                            while (Grid[line+1, j] == 0)  //devansam pana gasim un el
                            {
                                line++;
                            }
                            if (line < 5 && Grid[i, j] == Grid[line+1, j]) //daca el gasit e egal cu cel initial
                            {
                                Grid[i, j] = 0; // el initial devine nul 
                                Grid[line+1, j] = Grid[line+1, j] * -2; //el gasit se inmulteste cu 2 si  cu -1 pentru a nu se repeta operatia;
                                Score = Score + Grid[line+1, j] * -1;
                            }
                            else if (line <5 && Grid[i, j] != Grid[line+1, j]) //daca exista elemente nule intre 2 el diferite
                            {
                                Grid[line, j] = Grid[i, j];
                                Grid[i, j] = 0;
                            }
                            else if (line == 5) //daca toate el sunt nule
                            {
                                Grid[line - 1, j] = Grid[i, j];
                                Grid[i, j] = 0;
                            }
                        }
                        else if (Grid[i, j] == Grid[i + 1, j]) //daca el sunt egale
                        {
                            Grid[i, j] = 0;
                            Grid[i + 1, j] = Grid[i + 1, j] * -2;
                            Score = Score + Grid[i+1, j] * -1;
                        }
                    }
                }
            for (int i = 1; i <= 4; i++) //el inmultite cu -1 sunt puse in modul;
                for (int j = 1; j <= 4; j++)
                    if (Grid[i, j] < 0) Grid[i, j] = Grid[i, j] - 2 * Grid[i, j];
        }
        private void Akey()
        {
            int line;
            for (int i = 2; i <= 4; i++) //parcurgere matrice
                for (int j = 1; j <= 4; j++)
                {
                    if (Grid[j, i] != 0)
                    {
                        if (Grid[j, i-1] == 0) //daca el anterior e nul
                        {
                            line = i - 1;
                            while (Grid[j, line] == 0)  //devansam pana gasim un el
                            {
                                line--;
                            }
                            if (line > 0 && Grid[j, i] == Grid[j, line]) //daca el gasit e egal cu cel initial
                            {
                                Grid[j, i] = 0; // el initial devine nul 
                                Grid[j, line] = Grid[j, line] * -2; //el gasit se inmulteste cu 2 si  cu -1 pentru a nu se repeta operatia;
                                Score = Score + Grid[i, line] * -1;
                            }
                            else if (line > 0 && Grid[j, i] != Grid[j, line]) //daca exista elemente nule intre 2 el diferite
                            {
                                Grid[j, line+1] = Grid[j, i];
                                Grid[j, i] = 0;
                            }
                            else if (line == 0) //daca toate el sunt nule
                            {
                                Grid[j, line+1] = Grid[j, i];
                                Grid[j, i] = 0;
                            }
                        }
                        else if (Grid[j, i] == Grid[j, i-1]) //daca el sunt egale
                        {
                            Grid[j, i] = 0;
                            Grid[j, i-1] = Grid[j, i-1] * -2;
                            Score = Score + Grid[j, i-1] * -1;
                        }
                    }
                }
            for (int i = 1; i <= 4; i++) //el inmultite cu -1 sunt puse in modul;
                for (int j = 1; j <= 4; j++)
                    if (Grid[i, j] < 0) Grid[i, j] = Grid[i, j] - 2 * Grid[i, j];
        }
        private void Dkey()
        {
            int line;
            for (int i = 3; i >= 1; i--) //parcurgere matrice
                for (int j = 1; j <= 4; j++)
                {
                    if (Grid[j, i] != 0)
                    {
                        if (Grid[j, i + 1] == 0) //daca el anterior e nul
                        {
                            line = i+1;
                           
                            while (Grid[j, line] == 0)  //devansam pana gasim un el
                            {
                                line++;
                            }
                            if (line < 5 && Grid[j, i] == Grid[j, line]) //daca el gasit e egal cu cel initial
                            {
                                Grid[j, i] = 0; // el initial devine nul 
                                Grid[j, line] = Grid[j, line] * -2; //el gasit se inmulteste cu 2 si  cu -1 pentru a nu se repeta operatia;
                                Score = Score + Grid[i, line] * -1;
                            }
                            else if (line < 5 && Grid[j, i] != Grid[j, line]) //daca exista elemente nule intre 2 el diferite
                            {
                                Grid[j, line - 1] = Grid[j, i];
                                Grid[j, i] = 0;
                            }
                            else if (line == 5) //daca toate el sunt nule
                            {
                                Grid[j, line - 1] = Grid[j, i];
                                Grid[j, i] = 0;
                            }
                        }
                        else if (Grid[j, i] == Grid[j, i + 1]) //daca el sunt egale
                        {
                            Grid[j, i] = 0;
                            Grid[j, i + 1] = Grid[j, i + 1] * -2;
                            Score = Score + Grid[j, i+1] * -1;
                        }
                    }
                }
            for (int i = 1; i <= 4; i++) //el inmultite cu -1 sunt puse in modul;
                for (int j = 1; j <= 4; j++)
                    if (Grid[i, j] < 0) Grid[i, j] = Grid[i, j] - 2 * Grid[i, j];
        }
        private void ScoreUpdate()
        {
            label17.Text = "SCOR: " + Convert.ToString(Score); 
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            Bordare();
            InitializeGride();
            GridToLabels();
        }
        private void Form1_KeyUp(object sender, KeyEventArgs e)
        {
           if(MovesPossible()) //daca mai sunt miscari posibile 
           {
               CreateGridCopy();
                if (e.KeyCode == Keys.W) //verifica ce tasta s-a apasat 
                {
                      
                    WKey(); // se executa algoritmul pt respectiva tasta 
                   
                    if (!GridCheck()) //daca s-au produs modificari in matrice 
                    {
                        GridToLabels(); // se afiseaza
                        AddRandom(); //se adauga un nr random
                        ScoreUpdate();
                        
                    }
                }
                if (e.KeyCode == Keys.A)
                {
                    Akey();
                    if (!GridCheck())
                    {
                        GridToLabels();
                        AddRandom();
                        ScoreUpdate();
                        
                    }
                }
                if (e.KeyCode == Keys.S)
                {
     
                    SKey();
                  
                    if (!GridCheck())
                    {
                        GridToLabels();
                        AddRandom();
                        ScoreUpdate();
                    }
                }
                if (e.KeyCode == Keys.D)
                {
                    
                    Dkey();
                    if (!GridCheck())
                    {
                        GridToLabels();
                        AddRandom();
                        ScoreUpdate();
                    }
                }
           }
           else MessageBox.Show("NU MAI SUNT MISCARI POSIBILE");
        }

        private void label17_Click(object sender, EventArgs e)
        {

        }

    }
}
