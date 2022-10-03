package projetointegrador;

import java.sql.Connection;
import java.sql.ResultSet;
import java.sql.SQLException;
import java.sql.Statement;

public class TelaDeListagemDeCidades {
    
    public static void main(String[] args) {
        
        System.out.println("<<<<Listagem de Cidades>>>>");
        
        //Cria um gerenciador de conexao
        GerenciadorDeConexao gc = new GerenciadorDeConexao();
        
        //realiza conexão com o banco de dados
        Connection conexao = gc.Conectar();
    
        try 
        { 
            //sql a ser executado no banco de dados
            String sql = "select cidade.id, "
                       + "cidade.nome as `cidade`, "
                       + "estado.nome as `estado` "
                       + "from cidade "
                       + "inner join estado "
                       + "on cidade.id_estado = estado.id;";

            //cria o comando a ser executado no banco de dados
            Statement comando = conexao.createStatement();
            
            //executa o comando no banco de dados e armazena a resposta na memória 
            ResultSet resultado = comando.executeQuery(sql);
            
            //percorre os dados armazenados na memória e apresentam na tela
            while(resultado.next()) {
                System.out.print("Id: " + resultado.getInt("id"));
                System.out.print(" - ");
                System.out.print("Nome: " + resultado.getString("cidade"));
                System.out.print(" - "); 
                System.out.print("Estado: " + resultado.getString("estado"));
                System.out.println();
            }
        }
        catch (SQLException ex) 
        {
            System.out.println("Não conseguiu consultar os dados das cidades.");
        } 
        finally 
        {
            //Desconecta o banco de dados
            gc.Desconectar(conexao);
        }
    }
        
        
        
        
    }
    

