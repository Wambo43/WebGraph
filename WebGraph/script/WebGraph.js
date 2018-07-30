var nodes;
var edges;
var network =null;
$(function () {

    var seed = 2;


    function draw(_nodes, _edges) {
        destroy();

        // create a network
        var container = document.getElementById('mynetwork');
        var options = {
            layout: { randomSeed: seed }, // just to make sure the layout is the same when the locale is changed
            locale: 'de',
            edges: {
                smooth: false
            },
            physics: {
                enabled: false,
            },
            manipulation: {
                addNode: function (data, callback) {
                    // filling in the popup DOM elements
                    document.getElementById('node-operation').innerHTML = "Add Node";
                    document.getElementById('node-id').value = Math.floor((Math.random() * 100) + 1);
                    document.getElementById('node-label').value = data.label;
                    document.getElementById('saveNodeButton').onclick = saveNodeData.bind(this, data, callback);
                    document.getElementById('cancelNodeButton').onclick = clearNodePopUp.bind();
                    document.getElementById('node-network-popUp').style.display = 'block';
                },
                editNode: function (data, callback) {
                    // filling in the popup DOM elements
                    document.getElementById('node-operation').innerHTML = "Edit Node";
                    document.getElementById('node-id').value = data.id;
                    document.getElementById('node-label').value = data.label;
                    document.getElementById('saveNodeButton').onclick = saveNodeData.bind(this, data, callback);
                    document.getElementById('cancelNodeButton').onclick = cancelNodeEdit.bind(this, callback);
                    document.getElementById('node-network-popUp').style.display = 'block';
                },
                addEdge: function (data, callback) {
                    if (data.from == data.to) {
                        var r = confirm("Bitte keine Schleifen");
                    }
                    else { 
                        data.id = parseInt(Math.random() * 1000000000, 10);
                        data.label = Math.floor((Math.random() * 100) + 1);
                        data.value = data.label;
                        // filling in the popup DOM elements
                        document.getElementById('edge-operation').innerHTML = "Add Kante";
                        document.getElementById('edge-id').value = data.id;
                        document.getElementById('edge-value').value = data.label;
                        document.getElementById('saveEdgeButton').onclick = saveEdgeData.bind(this, data, callback);
                        document.getElementById('cancelEdgeButton').onclick = cancelEdgeEdit.bind(this, callback);
                        document.getElementById('edge-network-popUp').style.display = 'block';
                    }

                },
                editEdge: function (data, callback) {
                    // filling in the popup DOM elements
                    document.getElementById('edge-operation').innerHTML = "Add Kante";
                    document.getElementById('edge-id').value = data.id;
                    document.getElementById('edge-value').value = data.label;
                    document.getElementById('saveEdgeButton').onclick = saveEdgeData.bind(this, data, callback);
                    document.getElementById('cancelEdgeButton').onclick = cancelEdgeEdit.bind(this, callback);
                    document.getElementById('edge-network-popUp').style.display = 'block';
                }
            }
        };
        nodes = new vis.DataSet(_nodes);
        edges = new vis.DataSet(_edges);
        var data = {
            nodes: nodes,
            edges: edges
        };
        network = new vis.Network(container, data, options);
    }
    //Node
    function clearNodePopUp() {
        document.getElementById('saveNodeButton').onclick = null;
        document.getElementById('cancelNodeButton').onclick = null;
        document.getElementById('node-network-popUp').style.display = 'none';
    }

    function cancelNodeEdit(callback) {
        clearNodePopUp();
        callback(null);
    }

    function saveNodeData(data, callback) {
        data.id = document.getElementById('node-id').value;
        data.label = document.getElementById('node-label').value;
        clearNodePopUp();
        callback(data);
    }
    //Edge
    function clearEdgePopUp() {
        document.getElementById('saveEdgeButton').onclick = null;
        document.getElementById('cancelEdgeButton').onclick = null;
        document.getElementById('edge-network-popUp').style.display = 'none';
    }

    function cancelEdgeEdit(callback) {
        clearEdgePopUp();
        callback(null);
    }

    function saveEdgeData(data, callback) {
        data.id = document.getElementById('edge-id').value;
        data.value = document.getElementById('edge-value').value;
        data.label = document.getElementById('edge-value').value;
        clearEdgePopUp();
        callback(data);
    }


    nodes = [
        { id: 10, label: 'Node 0' },
        { id: 1, label: 'Node 1' },
        { id: 20, label: 'Node 2' },
        { id: 3, label: 'Node 3' },
        { id: 4, label: 'Node 4' },
        { id: 5, label: 'Node 5' },
        { id: 6, label: 'Node 6' },
        { id: 7, label: 'Node 7' },
        { id: 8, label: 'Node 8' },
        { id: 9, label: 'Node 9' },
    ];
    edges = [
        { from: 10, to: 20, value: 3, label: "3", },
        { from: 1, to: 20, value: 3, label: "3", },
        { from: 20, to: 9, value: 1, label: "1", },
        { from: 8, to: 3, value: 4, label: "4", },
        { from: 4, to: 6, value: 8, label: "8", },
        { from: 5, to: 7, value: 2, label: "2", },
        { from: 4, to: 5, value: 1, label: "1", },
        { from: 20, to: 3, value: 6, label: "6", },
        { from: 3, to: 9, value: 4, label: "4", },
        { from: 5, to: 3, value: 1, label: "1", },
        { from: 20, to: 7, value: 4, label: "4", },
        { from: 20, to: 7, value: 4, label: "4", },
        { from: 20, to: 8, value: 5, label: "5", }
    ];

    draw(nodes, edges);

    function destroy() {
        if (network !== null) {
            network.destroy();
            network = null;
        }
    }
    $('#calulateMST').click(function () {
        var arrayNodes = new Array();
        var arrayEdges = new Array();
        for (var node in nodes._data)
            arrayNodes.push(nodes._data[node]);
        for (var edge in edges._data)
            arrayEdges.push(edges._data[edge]);
        jsonTet = JSON.stringify({ nodes: arrayNodes, edges: arrayEdges });
        $.ajax({
            type: "POST",
            contentType: "application/json; charset=utf-8",
            url: "Content.asmx/MST",
            data: jsonTet,
            dataType: "json",
            success: function (json) {
                var data = json.d
                //resetAll();
                try {
                    for (var i = 0; i < data.length; ++i)
                        updateEdge(data[i]);
                }
                catch (err) {
                    alert("Der Graph muss zusammenhängend sein");
                }
            },
            error: function (json) {
                console.log(json);
                alert("Es entsteht ein Fehler beim Senden");
            },
        });
    })

    function updateEdge(edge) {
        try {
            edges.update({
                id: edge.id,
                from: edge.from,
                to: edge.to,
                value: edge.value,
                label: edge.label,
                color: edge.color,
            });
        }
        catch (err) {
            alert(err);
        }
    }
});