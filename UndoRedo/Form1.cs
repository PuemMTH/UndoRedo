namespace UndoRedo
{
    public partial class Form1 : Form
    {
        private Stack<String> KeyUndo = new Stack<String>();
        private Stack<String> KeyRedo = new Stack<String>();
        String tmp;

        public Form1()
        {
            InitializeComponent();
            tmp = "";
        }
        private void Undo_Keys_Click(object sender, EventArgs e)
        {
            if (KeyUndo.Count != 0)
            {
                tmp = KeyUndo.Peek();
                KeyRedo.Push(tmp);
                KeyUndo.Pop();
                TextBox_Center.Text = KeyRedo.Peek();
            }
            else if (KeyRedo.Count == 0)
            {
                MessageBox.Show("Can't Undo");
            }
        }

        private void Redo_Keys_Click(object sender, EventArgs e)
        {
            if (KeyRedo.Count != 0)
            {
                TextBox_Center.Text = KeyRedo.Peek();
                KeyUndo.Push(KeyRedo.Peek());
                KeyRedo.Pop();
            }
            else if (KeyRedo.Count == 0)
            {
                MessageBox.Show("Can't Redo");
            }
        }

        private void KeyUp_Onchange(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter || e.KeyCode == Keys.Space)
            {
                KeyUndo.Push(TextBox_Center.Text);
            }
        }

    }
}