new Chart(document.getElementById("pie-chart"), {
    type: 'pie',
    data: {
      labels: ["Male", "Female"],
      datasets: [{
        label: "Gender Distirbution",
        backgroundColor: ["#2dbaa5", "#ffce6f"],
        data: [147,126]
      }]
    },
    options: {
      title: {
        display: true
      }
    }
});