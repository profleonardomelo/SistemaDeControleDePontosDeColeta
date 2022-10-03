<!DOCTYPE HTML>
<html>

<body>

     <?php
      include 'VerificarAcesso.php';
     ?>

     <a href="EncerrarSessao.php">Sair</a>

      <h2>Cadastro de Estado</h2>
      <br>
      <form action="CadastrarEstado_.php" method="post">
            Nome: <input type="text" name="nome"><br><br><br>
            <input type="submit" value="Cadastrar">
      </form>


</body>

</html>