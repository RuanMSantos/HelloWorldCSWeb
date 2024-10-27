document.addEventListener("DOMContentLoaded", async () => {
    const mensagem = document.getElementById("mensagem");
    const response = await fetch("/hello-world");
    const result = await response.json();
    mensagem.innerHTML = result.mensagem;
  });