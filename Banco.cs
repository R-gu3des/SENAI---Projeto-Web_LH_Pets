using System.Data.SqlClient;


namespace PROJETO_WEB_LH
{
    class Banco
    {

        private List<Clientes> lista = new List<Clientes>();

        public List<Clientes> GetLista(){
            return lista;
        }

        public Banco()
        {
            try
            {
                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder
                (
                    "User ID=root;Password=;" +
                    "Server=localhost\\SQLEXPRESS;" +
                    "Darabase=vendas;" +
                    "Trusted_Connection=False;"
                );

                using (SqlConnection conexao = new SqlConnection(builder.ConnectionString)){
                    String sql = "SELECT * FROM tblClientes";
                    using (SqlCommand comando = new SqlCommand(sql, conexao)){
                        conexao.Open();
                        using (SqlDataReader tabela =  comando.ExecuteReader()){
                            while(tabela.Read()){
                                lista.Add(new Clientes(){
                                    cpf_cnpj = tabela["cpf_cnpj"].ToString(),
                                    nome = tabela["nome"].ToString(),
                                    endereco = tabela["endereco"].ToString(),
                                    rg_ie = tabela["rg_ie"].ToString(),
                                    tipo = tabela["tipo"].ToString(),
                                    valor = (float)Convert.ToDecimal(tabela["valor"]),
                                    valor_imposto = (float)Convert.ToDecimal(tabela["valor_imposto"]),
                                    total = (float)Convert.ToDecimal(tabela["total"])
                                });
                                    
                                
                            }
                        }
                    }
                }

            }catch (Exception e){
                Console.WriteLine(e);
            }
               
        }
        public string GetListaString(){
            string enviar = "<!DOCTYPE html>\n<html>\n<head>\n<meta charset='utf-8' />" +
            "<title>Cadaastro de Clientes</title>\n</head>\n<body>";
            enviar = enviar + "<b> CPF / CNPJ    -   NOME    -   Endereço   RG / IE  - Tipo  -  Valor";

            int i=0;
            string corFundo="", corTexto="";

            foreach (Clientes cli in GetLista()){
                if (i % 2 == 0){corFundo="#6f47ff"; corTexto="white";}
                else{corFundo="#ffffff"; corTexto="#6f47ff";}
                i++;

                enviar = enviar + $"\n<br><div style='background-color:{corFundo}; color:{corTexto};'>" +
                cli.cpf_cnpj + " - " +
                cli.nome + " - " + cli.endereco + " - " + cli.rg_ie + " - " +
                cli.tipo + " - " + cli.valor.ToString("C") + " - " +
                cli.valor_imposto.ToString("c") + " - " + cli.total.ToString("c") + "<br>" + "</div>";
            }
            return enviar;
        }
        
        public void imprimirListaConsole(){
            Console.WriteLine("     CPF / CNPJ     " + " - " + "    NOME    " + " - " + "   ENDEREÇO    " + " - " + " RG / IE" + " - " +
            "   TIPO    " + " - " + "   Valor   " + " - " + "Valor Imposto" + " - " + "Total");

            foreach(Clientes cli in GetLista()){
                Console.WriteLine(cli.cpf_cnpj + " - " + 
                cli.nome + " - " +  cli.endereco + " - " + cli.rg_ie + " - " +
                cli.tipo + " - " + cli.valor.ToString("C") + " - " +
                cli.valor_imposto.ToString("C") + " - " + cli.total.ToString("C")
                );
            }
        }
    }

}
// Server=localhost\SQLEXPRESS;Database=master;Trusted_Connection=True;