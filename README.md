# ANTSQLParser

	sqlparser -s "select a from b" -o json
	{"value":"\u003CEOF\u003E","token":"","rule":"tsql_file","children":[{"value":null,"token":null,"rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":"select","token":"SELECT","rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":"a","token":"ID","rule":null,"children":[]}]}]}]}]},{"value":null,"token":null,"rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":null,"token":null,"rule":null,"children":[{"value":"b","token":"ID","rule":null,"children":[]}]}]}]}]}]}]}]}]}]}]}]}]}]}]}]}

	sqlparser -s "select a from b" -o xml
	<node token="" rule="tsql_file" value="&lt;EOF&gt;"><node token="" rule="" value=""><node token="" rule="" value=""><node token="" rule="" value=""><node token="" rule="" value=""><node token="" rule="" value=""><node token="" rule="" value=""><node token="SELECT" rule="" value="select"><node token="" rule="" value=""><node token="" rule="" value=""><node token="" rule="" value=""><node token="" rule="" value=""><node token="ID" rule="" value="a" /></node></node></node></node><node token="" rule="" value=""><node token="" rule="" value=""><node token="" rule="" value=""><node token="" rule="" value=""><node token="" rule="" value=""><node token="" rule="" value=""><node token="" rule="" value=""><node token="ID" rule="" value="b" /></node></node></node></node></node></node></node></node></node></node></node></node></node></node></node>
