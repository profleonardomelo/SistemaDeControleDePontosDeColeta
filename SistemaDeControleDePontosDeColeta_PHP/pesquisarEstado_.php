<?php
 
 include 'VerificarAcesso.php';

 echo '<a href="EncerrarSessao.php">Sair</a>'; 

$id = $_POST["id"];
$nome = $_POST["nome"];

echo "<h2>Lista de estados</h2>";

include 'DadosDeConexao.php';

$conexao = new mysqli($servidor, $usuario, $senha, $bancodedados);

if ($conexao->connect_error) {
    die("A conexão com o banco de dados falhou. Erro: " . $conexao->connect_error);
}

if ($nome == '' && $id == '') {
  $comando = $conexao->prepare("SELECT id, nome FROM `bd_lixo_eletronico`.`estado`;");
}

if ($nome != '' && $id == '') {
  $comando = $conexao->prepare("SELECT id, nome FROM `bd_lixo_eletronico`.`estado` WHERE nome =?;");
  
  $comando->bind_param("s", $nome);
}

if ($nome == '' && $id != '') {
  $comando = $conexao->prepare("SELECT id, nome FROM `bd_lixo_eletronico`.`estado` WHERE id =?;");
  
  $comando->bind_param("i", $id);
}

if ($nome != '' && $id != '') {
  $comando = $conexao->prepare("SELECT id, nome FROM `bd_lixo_eletronico`.`estado` WHERE id =? AND nome=?;");
  
  $comando->bind_param("is", $id, $nome);
}

$comando->execute();

$resultado = $comando->get_result();

if ($resultado->num_rows > 0) {

  echo "<form action='ExcluirEstado.php' method='post'>";

  echo ("<table border='1' style='border-collapse: collapse'>");

  echo("<tr>");
    
     echo("<th></th>");
     echo("<th>ID</th>");
     echo("<th>Nome</th>");
     echo("<th></th>");

  echo("</tr>");

  while ($linha = $resultado->fetch_assoc()) {
    
    echo("<tr>");
    
      echo("<td>");
        echo "<input name='check_list[]' type='checkbox' value='" . $linha["id"] . "'>";
      echo("</td>");

      echo("<td>");
        echo ($linha["id"]);
      echo("</td>");
      
      echo("<td>");
        echo ($linha["nome"]);
      echo("</td>");

      echo("<td>"); 
        echo ("<input type=\"button\" value=\"Editar\" onclick=\"location.href='EditarEstado.php?id=" . $linha["id"] . "'\" />");
      echo("</td>");
    
    echo("</tr>");

  }

  echo ("</table>");

  echo ("&nbsp;");
  
  echo ("<br/>");

  echo "<input type='submit' onclick='return confirm(\"Deseja realmente excluir a(s) estado(s) selecionada(s)?\")' value='Excluir'>";
  echo "&nbsp;&nbsp;";
  echo '<a href="cadastrarEstado.php">Cadastrar Estado</a>';

  echo "</form>";

} 
else 
{
    echo "Sem registros de estado no sistema.<br><br>";
}



$comando->close();
$conexao->close();