using System.Text;

namespace Vista
{
    public partial class FrmContador : Form
    {
        Dictionary<string, int> palabras = new Dictionary<string, int>();
        public FrmContador()
        {
            InitializeComponent();
        }

        private void btnCalcular_Click(object sender, EventArgs e)
        {
            string[] arrayTexto = rboTexto.Text.Split(new char[] { ' ', '.', ',' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (string item in arrayTexto)
            {
                if (palabras.ContainsKey(item))
                {
                    palabras[item]++;
                }
                else
                {
                    palabras.Add(item, 1);
                }
            }
            MostrarTop();
        }

        private void MostrarTop()
        {
            StringBuilder sb = new StringBuilder();
            palabras = palabras.OrderByDescending(x => x.Value).ToDictionary(x => x.Key, x => x.Value);

            int i = 0;
            foreach (KeyValuePair<string, int> item in palabras)
            {
                sb.AppendLine($"{item.Key} - {item.Value}");
                i++;
                if (i == 3)
                {
                    break;
                }
            }
            MessageBox.Show(sb.ToString());
        }

        private void FrmContador_Load(object sender, EventArgs e)
        {
            rboTexto.Text = "In sem justo, commodo ut, suscipit at, pharetra vitae, orci. Duis sapien nunc, commodo et, interdum suscipit, sollicitudin et, dolor. Pellentesque habitant morbi tristique senectus et netus et malesuada fames ac turpis egestas. Aliquam id dolor. Class aptent taciti sociosqu ad litora torquent per conubia nostra, per inceptos hymenaeos. Mauris dictum facilisis augue. Fusce tellus. Pellentesque arcu. Maecenas fermentum, sem in pharetra pellentesque, velit turpis volutpat ante, in pharetra metus odio a lectus. Sed elit dui, pellentesque a, faucibus vel, interdum nec, diam. Mauris dolor felis, sagittis at, luctus sed, aliquam non, tellus. Etiam ligula pede, sagittis quis, interdum ultricies,";
        }
    }
}