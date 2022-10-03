<?php
 
 include 'VerificarAcesso.php';

 echo '<a href="EncerrarSessao.php">Sair</a>';

echo "<h2>Exclusão de Estados</h2>";

if (empty($_POST['check_list'])) 
{
  echo ("Não foram selecionados Estados a serem deletados.<br><br>");
} 
else 
{
  include 'DadosDeConexao.php';

  $conexao = new mysqli($servidor, $usuario, $senha, $bancodedados);

  if ($conexao->connect_error) {
    die("A conexão com o banco de dados falhou. Erro: " . $conexao->connect_error);
  }
  
  $comando = $conexao->prepare("DELETE FROM `bd_lixo_eletronico`.`estado` WHERE id=?;");

  $sucessoDelete = TRUE;

  foreach ($_POST['check_list'] as $id) {

    $comando->bind_param("i", $id);

    if (!($comando->execute() === TRUE)) {

      echo "Erro ao tentar excluir o Estado " . $id . ": " . $conexao->error;
      $sucessoDelete = FALSE;
    } 
    else 
    {
      echo "Estado com ID " . $id . " apagado.<br>";
    }
  }

  $comando->close();
  $conexao->close();

  if ($sucessoDelete) 
  {
    echo "<br>Estado(s) apagado(s) com sucesso.<br><br>";
  } 
  else 
  {
    echo "Existe(m) estado(s) não apagado(s) com sucesso.<br><br>";
  }
}

