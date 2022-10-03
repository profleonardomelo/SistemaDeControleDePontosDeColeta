<?php
 
 include 'VerificarAcesso.php';
 
 echo '<a href="EncerrarSessao.php">Sair</a>';
 
echo "<h2>Cadastro de Estado</h2>";

if (empty($_POST['nome'])) {
  echo ("O campo é Obrigatório.<br><br>");
  die();
}

$nome = $_POST["nome"];


include 'DadosDeConexao.php';

$conexao = new mysqli($servidor, $usuario, $senha, $bancodedados);

if ($conexao->connect_error) {
  die("A conexão com o banco de dados falhou. Erro: " . $conexao->connect_error);
}

$comando = $conexao->prepare("INSERT INTO `bd_lixo_eletronico`.`estado`
(`nome`)
VALUES
(?);");

$comando->bind_param("s", $nome);
echo $nome;
$resposta = $comando->execute();

if ($resposta === TRUE) {

  $id = $conexao->insert_id;
 
  echo "Conta criada com sucesso! <br> Número de ID gerado no cadastro foi: " . $id . ".<br><br>";

} 
else 
{
  echo "Erro ao tentar cadastrar uma nova conta: " . $conexao->error . "<br><br>";
}

$comando->close();
$conexao->close();