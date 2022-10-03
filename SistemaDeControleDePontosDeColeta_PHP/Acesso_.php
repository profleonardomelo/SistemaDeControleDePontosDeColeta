<?php

$l = "";
$s = "";

if(isset($_POST["login"]) && isset($_POST["senha"]))
{
    $l = $_POST["login"];
    $s = $_POST["senha"];
}

if ($l == '' || $s == '') {

    echo ("<h2>Acesso Ao Sistema Não Permitido</h2>");

    echo ("Os campos Login e Senha são obrigatórios.<br><br>");

    echo ("<input type=\"button\" value=\"Voltar\" onclick=\"location.href='Acesso.php'\" />");

    die();
}

include 'DadosDeConexao.php';

$conexao = new mysqli($servidor, $usuario, $senha, $bancodedados);

if ($conexao->connect_error) {
    die("A conexão com o banco de dados falhou. Erro: " . $conexao->connect_error);
}

$comando = $conexao->prepare("SELECT id FROM usuario WHERE login=? AND senha=?;");

$comando->bind_param("ss", $l, $s);

$comando->execute();
$resultado = $comando->get_result();

$comando->close();
$conexao->close();

if ($resultado->num_rows == 1) {

    session_start();

    $_SESSION['logado'] = true;

    header("Location: PesquisarEstado.php");

} 
else 
{
    session_start();

    session_unset();
    session_destroy();

    include("VerificarAcesso.php");
}