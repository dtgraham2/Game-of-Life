using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

public partial class _Default : System.Web.UI.Page
{
    char[,] Population = {     { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                               { 'x', 'x', 'x', 'x', 'x', '.', 'x', 'x', 'x', 'x'},
                               { 'x', 'x', 'x', '.', '.', '.', 'x', 'x', 'x', 'x'},
                               { 'x', '.', 'x', 'x', 'x', 'x', 'x', 'x', '.', 'x'},
                               { 'x', '.', '.', '.', '.', '.', '.', '.', '.', 'x'},
                               { 'x', 'x', 'x', '.', 'x', 'x', '.', 'x', 'x', 'x'},
                               { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                               { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                               { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'},
                               { 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x', 'x'}};
    int columns = 9;
    int rows = 9;
    bool first;

    protected void Page_Load(object sender, EventArgs e)
    {
        if (Page.IsPostBack)
        {
            Population = (char[,])Session["population"];
        }
        else
        {
            Session.Add("population", Population);
        }
    }


    public void runGen(object sender, EventArgs e)
    {
        char[,] tempStorage = new char[rows + 1, columns + 1];

        Response.Write("<code>");
            for (int i = 0; i <= columns; i++)
            {
                for (int j = 0; j <= rows; j++)
                {
                    
                    int neighborsAlive = 0;
                    if (i > 0 && j > 0)
                    {
                        if (Population[i - 1, j - 1] == '.')
                            neighborsAlive++;
                    }
                    if (j > 0)
                    {
                        if (Population[i, j - 1] == '.')
                            neighborsAlive++;
                    }
                    if (i > 0)
                    {
                        if (Population[i - 1, j] == '.')
                            neighborsAlive++;
                    }
                    if (i > 0 && j < columns)
                    {
                        if (Population[i - 1, j + 1] == '.')
                            neighborsAlive++;
                    }
                    if (i < columns && j > 0)
                    {
                        if (Population[i + 1, j - 1] == '.')
                            neighborsAlive++;
                    }
                    if (j < columns)
                    {
                        if (Population[i, j + 1] == '.')
                            neighborsAlive++;
                    }
                    if (i < columns)
                    {
                        if (Population[i + 1, j] == '.')
                            neighborsAlive++;
                    }

                    if (i < columns && j < columns)
                    {
                        if (Population[i + 1, j + 1] == '.')
                            neighborsAlive++;
                    }

                    if (neighborsAlive == 2 && Population[i, j] == '.')
                    {
                        tempStorage[i, j] = '.';
                    }
                else
                {
                    tempStorage[i, j] = 'x';
                }

                    if (neighborsAlive == 3)
                    {
                        tempStorage[i, j] = '.';
                    }
                    if (neighborsAlive < 2 || neighborsAlive > 3)
                    {
                        tempStorage[i, j] = 'x';
                    }
            }
        }

        for (int i = 0; i <= rows; i++)
        {
            for(int j = 0; j <= columns; j++)
            {
                Population[i, j] = tempStorage[i, j];
                Response.Write(Population[i, j] + " ");
            }
            Response.Write("<br/>");
        }

    }   
}
