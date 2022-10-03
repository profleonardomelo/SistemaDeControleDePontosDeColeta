<?php
 
 include 'VerificarAcesso.php';

 echo '<a href="EncerrarSessao.php">Sair</a>';

echo "<h2>Edição de Estado</h2>";

if (empty($_POST['id']) || empty($_POST['nome']) ) {
  echo ("Os campos 'id' e 'Nome' são Obrigatórios.");  
  die();
}

$id = $_POST["id"];
$nome = $_POST["nome"];

include 'DadosDeConexao.php';

$conexao = new mysqli($servidor, $usuario, $senha, $bancodedados);

if ($conexao->connect_error) {
  die("A conexão com o banco de dados falhou. Erro: " . $conexao->connect_error);
}

$comando = $conexao->prepare("UPDATE `bd_lixo_eletronico`.`estado` SET `nome`=? WHERE `id`=?;");

$comando->bind_param("si", $nome, $id);

if ($comando->execute() === TRUE) {
  echo "Estado " . $id . " editado com sucesso!";
} 
else 
{
  echo "Erro ao tentar editar um Estado: " . $conexao->error;
}

$comando->close();
$conexao->close();