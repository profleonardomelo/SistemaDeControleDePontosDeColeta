<?php

$id = "";

if(isset($_GET["id"]))
{
    $id = $_GET["id"];
}

 include 'VerificarAcesso.php';

 echo '<a href="EncerrarSessao.php">Sair</a><br><br>';

include 'dadosDeConexao.php';

$conexao = new mysqli($servidor, $usuario, $senha, $bancodedados);

if ($conexao->connect_error) {
    die("A conexão com o banco de dados falhou. Erro: " . $conexao->connect_error);
}

$comando = $conexao->prepare("SELECT id, nome FROM `bd_lixo_eletronico`.`estado` WHERE id =?;");

$comando->bind_param("i", $id);

$comando->execute();
$resultado = $comando->get_result();

if ($resultado->num_rows > 0) {
    while ($linha = $resultado->fetch_assoc()) {

        $nome = $linha["nome"];


        echo ("<h2>Edição de Estado</h2>");
        echo ("<br>");
        echo ("<form action=\"EditarEstado_.php\" method=\"post\">");
        echo ("ID do Estado: <input type=\"text\" name=\"id2\"  value=\"" . $id . "\" disabled><br><br>");
        echo ("<input type=\"hidden\" name=\"id\"  value=\"" . $id . "\">");
        echo ("Nome do Estado: <input type=\"text\" name=\"nome\"  value=\"" . $nome . "\"><br><br>");
        echo ("&nbsp;");
        echo ("<input type=\"submit\" value=\"Editar\">");
        echo ("</form>");
    }
} else {
    echo ("É necessário informar um ID válido para editar um estado.<br><br>");
}

$comando->close();
$conexao->close();