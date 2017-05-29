var TemplateEngine = function(html, options) {
    var re = /<%([^%>]+)?%>/g, reExp = /(^( )?(if|for|else|switch|case|break|{|}))(.*)?/g, code = 'var r=[];\n', cursor = 0, match;
    var add = function(line, js) {
        js? (code += line.match(reExp) ? line + '\n' : 'r.push(' + line + ');\n') :
            (code += line != '' ? 'r.push("' + line.replace(/"/g, '\\"') + '");\n' : '');
        return add;
    }
    while(match = re.exec(html)) {
        add(html.slice(cursor, match.index))(match[1], true);
        cursor = match.index + match[0].length;
    }
    add(html.substr(cursor, html.length - cursor));
    code += 'return r.join("");';
    return new Function(code.replace(/[\r\t\n]/g, '')).apply(options);
}

const messageLeftTemplate = 
    `<li class="left clearfix">
        <span class="chat-img pull-left">
            <img src="<%this.Usuario.Foto%>" class="img-circle" />
        </span>
        <div class="chat-body clearfix">
            <div class="header">
                <strong class="primary-font"><%this.Usuario.Nome%></strong> 
                <small class="pull-right text-muted">
                    <span class="glyphicon glyphicon-time"></span><%converteDataParaString(new Date(this.Timestamp))%>
                </small>
            </div>
            <p>
                <%this.Texto%>    
            </p>
        </div>
    </li>`;

const messageRightTemplate = 
`<li class="right clearfix">
    <span class="chat-img pull-right">
        <img src="<%this.Usuario.Foto%>" class="img-circle" />
    </span>
    <div class="chat-body clearfix">
        <div class="header">
            <small class="text-muted">
                <span class="glyphicon glyphicon-time"></span><%converteDataParaString(new Date(this.Timestamp))%>
            </small>
            <strong class="pull-right primary-font"><%this.Usuario.Nome%></strong>
        </div>
        <p>
            <%this.Texto%>  
        </p>
    </div>
</li>`;

function converteDataParaString(data) {
    return  ("0" + data.getDate()).slice(-2) + "-" + ("0"+(data.getMonth()+1)).slice(-2) + "-" +
    data.getFullYear() + " " + ("0" + data.getHours()).slice(-2) + ":" + ("0" + data.getMinutes()).slice(-2);
}