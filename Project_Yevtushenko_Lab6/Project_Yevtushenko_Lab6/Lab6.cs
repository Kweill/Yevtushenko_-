using Core;
using System;
using System.Linq;
using System.Text.Json;
using System.Windows.Forms;
using System.IO;
using System.Collections.Generic;
using System.Xml.Serialization;

namespace Project_Yevtushenko_Lab6
{
    public partial class Lab6 : Form
    {
        private TransactionManager manager;

        public Lab6()
        {
            InitializeComponent();

            manager = new TransactionManager();

            openFileDialog1.Filter =
                "JSON files (*.json)|*.json|XML files (*.xml)|*.xml";

            saveFileDialog1.Filter =
                "JSON files (*.json)|*.json|XML files (*.xml)|*.xml";

            RefreshGrid();
        }

        private void RefreshGrid()
        {
            dataGridView1.DataSource = null;

            dataGridView1.DataSource = manager.GetAll()
                .Select(t => new
                {
                    t.Description,
                    Amount = t.Amount.ToCurrencyString(),
                    t.Date,
                    Type = t.GetTypeName()
                })
                .ToList();
        }

        // ADD
        private void button1_Click(object sender, EventArgs e)
        {
            using (var form = new EditTransactionForm())
            {
                if (form.ShowDialog() == DialogResult.OK &&
                    form.Result != null)
                {
                    manager.Add(form.Result);

                    RefreshGrid();
                }
            }
        }

        // DELETE
        private void button2_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow == null)
                return;

            var desc = dataGridView1.CurrentRow.Cells[0].Value;

            if (desc == null)
                return;

            var item = manager.GetAll()
                .FirstOrDefault(x => x.Description == desc.ToString());

            if (item != null)
            {
                manager.Remove(item);

                RefreshGrid();
            }
        }

        // SAVE
        private void button3_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = saveFileDialog1.FileName;

                // JSON
                if (path.EndsWith(".json"))
                {
                    var data = manager.GetAll()
                        .Select(t => new
                        {
                            Type = t.GetTypeName(),
                            t.Description,
                            t.Amount,
                            t.Date
                        })
                        .ToList();

                    var json = JsonSerializer.Serialize(
                        data,
                        new JsonSerializerOptions
                        {
                            WriteIndented = true
                        });

                    File.WriteAllText(path, json);
                }

                // XML
                else if (path.EndsWith(".xml"))
                {
                    var serializer = new XmlSerializer(
                        typeof(List<Transaction>),
                        new Type[]
                        {
                            typeof(IncomeTransaction),
                            typeof(ExpenseTransaction)
                        });

                    using (FileStream stream =
                           new FileStream(path, FileMode.Create))
                    {
                        serializer.Serialize(
                            stream,
                            manager.GetAll());
                    }
                }
            }
        }

        // LOAD
        private void button4_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string path = openFileDialog1.FileName;

                List<Transaction>? list = null;

                // JSON
                if (path.EndsWith(".json"))
                {
                    var json = File.ReadAllText(path);

                    var temp =
                        JsonSerializer.Deserialize<List<JsonElement>>(json);

                    list = new List<Transaction>();

                    foreach (var item in temp!)
                    {
                        string type =
                            item.GetProperty("Type").GetString()!;

                        string desc =
                            item.GetProperty("Description").GetString()!;

                        double amount =
                            item.GetProperty("Amount").GetDouble();

                        DateTime date =
                            item.GetProperty("Date").GetDateTime();

                        if (type == "Income")
                        {
                            list.Add(new IncomeTransaction
                            {
                                Description = desc,
                                Amount = amount,
                                Date = date
                            });
                        }
                        else
                        {
                            list.Add(new ExpenseTransaction
                            {
                                Description = desc,
                                Amount = amount,
                                Date = date
                            });
                        }
                    }
                }

                // XML
                else if (path.EndsWith(".xml"))
                {
                    var serializer = new XmlSerializer(
                        typeof(List<Transaction>),
                        new Type[]
                        {
                            typeof(IncomeTransaction),
                            typeof(ExpenseTransaction)
                        });

                    using (FileStream stream =
                           new FileStream(path, FileMode.Open))
                    {
                        list =
                            (List<Transaction>)serializer.Deserialize(stream)!;
                    }
                }

                manager = new TransactionManager();

                if (list != null)
                {
                    foreach (var t in list)
                    {
                        manager.Add(t);
                    }
                }

                RefreshGrid();
            }
        }
    }
}