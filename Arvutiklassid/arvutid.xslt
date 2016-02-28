<?xml version="1.0" encoding="utf-8"?>
<xsl:stylesheet version="1.0" xmlns:xsl="http://www.w3.org/1999/XSL/Transform"
    xmlns:msxsl="urn:schemas-microsoft-com:xslt" exclude-result-prefixes="msxsl"
>
  <xsl:template match="/">
    <html>
      <body>
        Arvutid:
        <xsl:for-each select="/arvutiklassid/arvutiklass">
          <ul>
            <li>
              <xsl:text>Klass </xsl:text>
              <xsl:value-of select="@ruuminumber"/>
              <ul>
                <xsl:for-each select="arvuti">
                  <li>
                    <xsl:text>Arvuti: </xsl:text>
                    <xsl:value-of select="@bränd"/>
                    <xsl:text> (Operatsionisüsteem: </xsl:text>
                    <xsl:value-of select="@os"/>
                    
                    <xsl:variable name="comment" select="@kommentaar" />
                    <xsl:if test="$comment != ''">
                      <xsl:text> (</xsl:text>
                      <xsl:value-of select="@kommentaar"/>
                      <xsl:text>)</xsl:text>
                    </xsl:if>
                    <xsl:text>)</xsl:text>
                  </li>
                </xsl:for-each>
              </ul>
            </li>
          </ul>
        </xsl:for-each>
      </body>
    </html>
  </xsl:template>
</xsl:stylesheet>
