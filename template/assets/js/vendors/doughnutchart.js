new Chart(document.getElementById("doughnut-chart"), {
    type: 'doughnut',
    data: {
      labels: ["Design", "Dev", "CEO"],
      datasets: [
        {
          label: "Income Analysis",
          backgroundColor: ["#ffa800", "#3445e5","#f66064"],
          data: [8,6,4]
        }
      ]
    },
    options: {
      title: {
        display: true
      }
    }
});