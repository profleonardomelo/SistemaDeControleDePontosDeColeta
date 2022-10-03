<!DOCTYPE HTML>
<html>

<body>
     <?php
      include 'VerificarAcesso.php';
     ?>

     <a href="EncerrarSessao.php">Sair</a>

      <h2>Pesquisar Estados</h2>
      <br>
      <form action="PesquisarEstado_.php" method="post">
            Id: <input type="text" name="id"><br><br>
            Nome do estado: <input type="text" name="nome"><br><br><br>
            <input type='reset' value='Limpar'>&nbsp;
            <input type="submit" value="Pesquisar"><br><br>
            <a href="cadastrarEstado.php">Cadastrar Estado</a>
      </form>

</body>

</html>