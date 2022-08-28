new Chart(document.getElementById("line-chart"), {
    type: 'line',
    data: {
      labels: ['Jan','Feb','Mar','Apr','May','Jun','Jul','Aug','Sep','Oct','Nov','Dec'],
      datasets: [{ 
          data: [86,114,106,106,107,111,133,221,783,2478,3235,4632],
          label: "Sales",
          borderColor: "#e3e6f8",
          fill: false
        }, { 
          data: [282,350,411,502,635,809,947,1402,3700,5267,6453,7443],
          label: "Marketing",
          borderColor: "#ffa800",
          fill: false
        }, { 
          data: [168,170,178,190,203,276,408,547,675,734,853,934],
          label: "Design",
          borderColor: "#2dbaa5",
          fill: false
        }, { 
          data: [40,20,10,16,24,38,74,167,508,784,954,1043],
          label: "Support",
          borderColor: "#3445e5",
          fill: false
        }, { 
          data: [6,3,2,2,7,26,82,172,312,433,532,631],
          label: "Development",
          borderColor: "#f66064",
          fill: false
        }
      ]
    },
    options: {
      title: {
        display: true
      }
    }
  });   