using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Estacionamento
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            Marca marca = new Marca();
            MarcaDAO marcaDAO = new MarcaDAO();
            List<Marca> marcas = null;
            marca.setCodMarca(1);
            marcas = marcaDAO.selectAll();
            foreach (Marca m in marcas)
            {
                MessageBox.Show(m.getCodMarca() + " - " + m.getDescricao());
            }
        }
    }
}
