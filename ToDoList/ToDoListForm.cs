using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ToDoList
{
    public partial class ToDoListForm : Form
    {
        public ToDoListForm()
        {
            InitializeComponent();
        }

        private void AddButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "";
            string item = addTextBox.Text.Trim();
            if (!item.Equals(""))
            {
                todoListBox.Items.Add(item);
            }
            else
            {
                statusLabel.Text = "The field 'Task' cannot be empty!";
            }
        }

        private void DeleteButton_Click(object sender, EventArgs e)
        {
            statusLabel.Text = "";
            object item = todoListBox.SelectedItem;
            if (item != null)
            {
                todoListBox.Items.Remove(item);
            }
            else
            {
                statusLabel.Text = "The task from To-Do list wasn't selected!";
            }
            showLabel.Text = "";
        }

        private void UpButton_Click(object sender, EventArgs e)
        {
            object item = todoListBox.SelectedItem;

            if (item != null)
            {
                int index = todoListBox.Items.IndexOf(item);

                if (index != 0)
                {
                    bool isChecked = todoListBox.GetItemChecked(index);

                    todoListBox.Items.Remove(item);
                    todoListBox.Items.Insert(index - 1, item);

                    todoListBox.SelectedItem = item;
                    todoListBox.SetItemChecked(index - 1, isChecked);
                }
                else
                {
                    statusLabel.Text = "The task is in the top!";
                }
            }
            else
            {
                statusLabel.Text = "The task from To-Do list wasn't selected!";
            }
        }

        private void DownButton_Click(object sender, EventArgs e)
        {
            object item = todoListBox.SelectedItem;

            if (item != null)
            {
                int index = todoListBox.Items.IndexOf(item);

                if (index != todoListBox.Items.Count - 1)
                {
                    bool isChecked = todoListBox.GetItemChecked(index);

                    todoListBox.Items.Remove(item);
                    todoListBox.Items.Insert(index + 1, item);

                    todoListBox.SelectedItem = item;
                    todoListBox.SetItemChecked(index + 1, isChecked);
                }
                else
                {
                    statusLabel.Text = "The task is in the bottom!";
                }
            }
            else
            {
                statusLabel.Text = "The task from To-Do list wasn't selected!";
            }
        }

        private void TodoListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            object item = todoListBox.SelectedItem;

            if (item != null)
            {
                showLabel.Text = item.ToString();
            }
        }

        private void NewMenuItem_Click(object sender, EventArgs e)
        {
            NewDialog newDialog = new NewDialog();

            newDialog.StartPosition = FormStartPosition.CenterParent;
            
            newDialog.ShowDialog();

            if (newDialog.DialogResult == DialogResult.OK)
            {
                addTextBox.Text = "";
                todoListBox.Items.Clear();

                if (!newDialog.Controls.Find("nameTextBox", false)[0].Text.Trim().Equals(""))
                {
                    Text = newDialog.Controls.Find("nameTextBox", false)[0].Text + " - ToDo List";

                    todoPanel.Enabled = true;
                    addLabel.Enabled = true;
                    addTextBox.Enabled = true;
                    addButton.Enabled = true;
                }
            }
            newDialog.Dispose();
        }

        private void ExitMenuItem_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void OpenMenuItem_Click(object sender, EventArgs e)
        {
            OpenDialog openDialog = new OpenDialog();

            openDialog.StartPosition = FormStartPosition.CenterParent;

            openDialog.ShowDialog();

            if (openDialog.DialogResult == DialogResult.OK)
            {
                addTextBox.Text = "";
                todoListBox.Items.Clear();

                ComboBox openComboBox = openDialog.Controls.Find("nameComboBox", false)[0] as ComboBox;

                if (openComboBox != null)
                {
                    Text = openComboBox.SelectedItem.ToString() + " - ToDo List";

                    todoPanel.Enabled = true;
                    addLabel.Enabled = true;
                    addTextBox.Enabled = true;
                    addButton.Enabled = true;
                }
            }
            openDialog.Dispose();
        }
    }
}
