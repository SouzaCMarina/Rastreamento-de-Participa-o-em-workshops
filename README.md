Na pasta Backend encontra-se uma API REST desenvolvida em C#, contendo classes de colaboradores e workshops.
Deve ser rodado na porta 5012.
Contém os seguintes endpoints:
Colaboradores:
Get: retorna a coleção colaboradores.
Get{id}: retorna o colaborador pelo id.
Post: adiciona um colaborador.
Put{id}: atualiza as informações do colaborador pelo id.
Delete{id}: exclui um colaborador pelo id.
Get{colaboradorId/workshops}: lista os workshops que um colaborador participou.

Workshops:
Get: retorna a coleção workshops.
Get{id}: retorna o workshop pelo id.
Post: adiciona um workshop.
Put{id}: atualiza as informações de um workshop.
Delete{id}: exclui um workshop por id.
Post{workshopId}/presença/{colaboradorid}: adiciona a presença de um colaborador em um workshop.
Get {workshopId}/presencas: retorna a lista de presença de um workshop por id.

Na pasta Frontend encontra-se o projeto em Angular com os seguintes componentes:
colaboradores;
colaboradores-lista;
workshops;
workshops-lista;
detalhes-workshop.
Deve ser rodado na porta 4200.
Exibirá a tela lista colaboradores.
