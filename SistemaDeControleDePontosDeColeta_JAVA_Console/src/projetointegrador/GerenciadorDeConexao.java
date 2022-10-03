package projetointegrador;

import java.sql.Connection;
import java.sql.DriverManager;
import java.sql.SQLException;

public class GerenciadorDeConexao {
    
    private String servidor = "127.0.0.1:3306";
    private String banco = "bd_lixo_eletronico";
    private String login = "root";
    private String senha = "root";
    
    public Connection Conectar() {
        
        Connection conexao = null;
    
        try 
        {    
            Class.forName("com.mysql.cj.jdbc.Driver");
            
            String textoDeConexao = "jdbc:mysql://" + this.servidor + "/" + this.banco;
            
            conexao = DriverManager.getConnection(textoDeConexao, this.login, this.senha);
        }
        catch (SQLException ex) 
        {
            System.out.println("Erro: Não conseguiu conectar no BD.");
        } 
        catch (ClassNotFoundException ex) 
        {
            System.out.println("Erro: Não encontrou o driver do BD.");
        }
        
        return conexao;
    }
    
    public void Desconectar(Connection conexao) {
        try 
        {
            if(conexao != null && !conexao.isClosed()) {
                conexao.close();
            }
        } 
        catch (SQLException ex) 
        {
            System.out.println("Não conseguiu desconectar do BD.");
        }
    }
    
}