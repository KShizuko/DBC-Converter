using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace DBC_Converter
{
     public partial class Form1 : Form
     {
          public Form1()
          {
               InitializeComponent();
          }
          private void button1_Click(object sender, EventArgs e)
          {
               DialogResult result = openFileDialog1.ShowDialog();
               if (result == DialogResult.OK)
               {
                    textBox1.Text = openFileDialog1.FileName.ToLower();
               }
          }
          private void button3_Click(object sender, EventArgs e)
          {
               if (File.Exists(textBox1.Text))
               {
                   switch (Header(textBox1.Text))
                   {
                       case "EFFE":
                           {
                               CO2_CORE_DLL.IO.DBC.EFFE dbc = new CO2_CORE_DLL.IO.DBC.EFFE();
                               if (isDBC(textBox1.Text))
                               {
                                   dbc.LoadFromDat(textBox1.Text);
                                   dbc.SaveToTxt(ExtDBC(true));
                               }
                               else
                               {
                                   dbc.LoadFromTxt(textBox1.Text);
                                   dbc.SaveToDat(ExtDBC(false));
                               }
                               Done();
                               break;
                           }
                       case "RSDB32":
                           {
                               CO2_CORE_DLL.IO.DBC.RSDB_SMALL dbc = new CO2_CORE_DLL.IO.DBC.RSDB_SMALL();
                               if (isDBC(textBox1.Text))
                               {
                                   dbc.LoadFromDat(textBox1.Text);
                                   dbc.SaveToTxt(ExtDBC(true));
                               }
                               else
                               {
                                   dbc.LoadFromTxt(textBox1.Text);
                                   dbc.SaveToDat(ExtDBC(false));
                               }
                               Done();
                               break;
                           }
                       case "RSDB64":
                           {
                               CO2_CORE_DLL.IO.DBC.RSDB_BIG dbc = new CO2_CORE_DLL.IO.DBC.RSDB_BIG();
                               if (isDBC(textBox1.Text))
                               {
                                   dbc.LoadFromDat(textBox1.Text);
                                   dbc.SaveToTxt(ExtDBC(true));
                               }
                               else
                               {
                                   dbc.LoadFromTxt(textBox1.Text);
                                   dbc.SaveToDat(ExtDBC(false));
                               }
                               Done();
                               break;
                           }
                       case "SIMO":
                           {
                               CO2_CORE_DLL.IO.DBC.SIMO dbc = new CO2_CORE_DLL.IO.DBC.SIMO();
                               if (isDBC(textBox1.Text))
                               {
                                   dbc.LoadFromDat(textBox1.Text);
                                   dbc.SaveToTxt(ExtDBC(true));
                               }
                               else
                               {
                                   dbc.LoadFromTxt(textBox1.Text);
                                   dbc.SaveToDat(ExtDBC(false));
                               }
                               Done();
                               break;
                           }
                       case "MESH":
                           {
                               CO2_CORE_DLL.IO.DBC.MESH dbc = new CO2_CORE_DLL.IO.DBC.MESH();
                               if (isDBC(textBox1.Text))
                               {
                                   dbc.LoadFromDat(textBox1.Text);
                                   dbc.SaveToTxt(ExtDBC(true));
                               }
                               else
                               {
                                   dbc.LoadFromTxt(textBox1.Text);
                                   dbc.SaveToDat(ExtDBC(false));
                               }
                               Done();
                               break;
                           }
                       case "EMOI":
                           {
                               CO2_CORE_DLL.IO.DBC.EMOI dbc = new CO2_CORE_DLL.IO.DBC.EMOI();
                               if (isDBC(textBox1.Text))
                               {
                                   dbc.LoadFromDat(textBox1.Text);
                                   dbc.SaveToTxt(ExtDBC(true));
                               }
                               else
                               {
                                   dbc.LoadFromTxt(textBox1.Text);
                                   dbc.SaveToDat(ExtDBC(false));
                               }
                               Done();
                               break;
                           }
                       case "MATR":
                           {
                               CO2_CORE_DLL.IO.DBC.MATR dbc = new CO2_CORE_DLL.IO.DBC.MATR();
                               if (isDBC(textBox1.Text))
                               {
                                   dbc.LoadFromDat(textBox1.Text);
                                   dbc.SaveToTxt(ExtDBC(true));
                               }
                               else
                               {
                                   dbc.LoadFromTxt(textBox1.Text);
                                   dbc.SaveToDat(ExtDBC(false));
                               }
                               Done();
                               break;
                           }
                       case "ROPT":
                           {
                               CO2_CORE_DLL.IO.DBC.ROPT dbc = new CO2_CORE_DLL.IO.DBC.ROPT();
                               if (isDBC(textBox1.Text))
                               {
                                   dbc.LoadFromDat(textBox1.Text);
                                   dbc.SaveToTxt(ExtDBC(true));
                               }
                               else
                               {
                                   dbc.LoadFromTxt(textBox1.Text);
                                   dbc.SaveToDat(ExtDBC(false));
                               }
                               Done();
                               break;
                           }
                       case "NONE":
                       default:
                           {
                               MessageBox.Show("The DBC file is not recognized.");
                               break;
                           }
                   }
               }
               else
               {
                    MessageBox.Show("You either forgot to select a file or somehow selected a non-existing one.");
               }
          }
          
          private void button2_Click(object sender, EventArgs e)
          {
               MessageBox.Show("So you probably clicked here because of the program not working.\nYou probably did something weird, try again.");
          }

          private void button4_Click(object sender, EventArgs e)
          {
              MessageBox.Show("Credits:\nCptSky for his .dll, program wouldn't have existed without him.\nMe for putting together this for the lazy ones.\nGoogle for random stuff.");
          }
          public bool isDBC(string path)
          {
              if (path.EndsWith(".dbc"))
                  return true;
              return false;
          }
          public string ExtDBC(bool Extension)
          {
              if (Extension)
                  return textBox1.Text.Replace(".dbc", ".txt");
              return textBox1.Text.Replace(".txt", ".dbc");
          }
          public string Header(string text)
          {
              if (text.Contains("3deffect") && !text.Contains("3deffectobj"))
                  return "EFFE";
              else if (text.Contains("3deffectobj") || text.Contains("3dobj") || text.Contains("3dtexture") || text.Contains("sound"))
                  return "RSDB32";
              else if (text.Contains("motion") && !text.Contains("emotionico"))
                  return "RSDB64";
              else if (text.Contains("3dsimpleobj"))
                  return "SIMO";
              else if (text.Contains("armet") || text.Contains("armor") || text.Contains("head") || text.Contains("misc") || text.Contains("mount") || text.Contains("weapon"))
                  return "MESH";
              else if (text.Contains("emotionico"))
                  return "EMOI";
              else if (text.Contains("material"))
                  return "MATR";
              else if (text.Contains("rolepart"))
                  return "ROPT";
              else
                  return "NONE";
          }
          public void Done()
          {
               MessageBox.Show("Done converting.");
          }
     }
}
